using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using MtWiki.DAL;
using MtWiki.DAL.Entities;
using MtWiki.DAL.Repositories;
using MtWiki.Import.Utils;
using Newtonsoft.Json.Linq;
using NLog;
using System.Xml;

namespace MtWiki.Import
{
    public class ExportAndImport
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public ExportAndImport(DbContextOptions<ApplicationDbContext> options)
        {
            _options = options;
        }

        public async Task TransferEmployeesFromExcelToDatabase(string employeesPath, string colsArrayPath, string userImgDownloadPath)
        {
            try
            {
                var employeesFromExcel = ReadEmployeesFromExcel(employeesPath);

                // Удаляем уволенных сотрудников из БД
                await RemoveNonActiveUsers(employeesFromExcel);

                // Заполняем добавочные данные сотрудника из внешнего файла xml
                PopulateUsersWithXmlData(employeesFromExcel, colsArrayPath, userImgDownloadPath);

                // Добавляем новых или обновляем существующих сотрудников в БД
                await UpdateOrCreateEmployeesInDatabase(employeesFromExcel);
                
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }

        private List<Employee> ReadEmployeesFromExcel(string path)
        {
            var employeesFromExcel = new List<Employee>();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var fStream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                var excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fStream);
                var resultDataSet = excelDataReader.AsDataSet();
                var table = resultDataSet.Tables[0];

                // Добавление сотрудников
                for (int rowCounter = 2; rowCounter < table.Rows.Count; rowCounter++)
                {
                    // Пропускаем, если по уходу за ребенком
                    if(Convert.ToString(table.Rows[rowCounter][27]) == "По уходу за ребенком")
                    {
                        continue;
                    }

                    var userFromExcel = new Employee
                    {
                        EmployeeServiceNumber = Convert.ToInt32(table.Rows[rowCounter][2]),
                        EmployeeName = Convert.ToString(table.Rows[rowCounter][3]),
                        EmployeePosition = Convert.ToString(table.Rows[rowCounter][6]),
                        EmployeeDepartment = Convert.ToString(table.Rows[rowCounter][22]),
                        EmployeeDivision = Convert.ToString(table.Rows[rowCounter][24]),
                        EmployeeSector = Convert.ToString(table.Rows[rowCounter][26])
                    };

                    employeesFromExcel.Add(userFromExcel);
                }

                excelDataReader.Close();
            }

            return employeesFromExcel;
        }

        private void PopulateUsersWithXmlData(List<Employee> employeesFromExcel, string colsArrayPath, string userImgDownloadPath)
        {
            var xmlDocument1 = new XmlDocument();
            xmlDocument1.Load(colsArrayPath);

            foreach (var userFromExcel in employeesFromExcel)
            {
                var parts = userFromExcel.EmployeeName.Split(' ');
                var firstName = parts[0];
                var lastName = parts.Length > 1 ? parts[1] : "";
                var middleName = parts.Length > 2 ? parts[2] : "";

                var xpath = $"//value[contains(., '{firstName}') and contains(., '{lastName}') and contains(., '{middleName}')]";

                var userNode1 = xmlDocument1.SelectSingleNode(xpath);

                if (userNode1 != null)
                {
                    var obj = JObject.Parse(userNode1.InnerText);

                    var base64Image = (string)obj["pict_url"];
                    var fileName = userFromExcel.EmployeeName.Replace(" ", "");
                    var imagePath = ImageUtilities.SaveBase64Image(base64Image, fileName, userImgDownloadPath);

                    userFromExcel.EmployeeImagePath = imagePath;
                }              
            }
        }

        private async Task UpdateOrCreateEmployeesInDatabase(List<Employee> employeesFromExcel)
        {
            using (var uow = new UnitOfWork(new ApplicationDbContext(_options)))
            {
                // Для каждого сотрудника
                foreach (var employeeFromExcel in employeesFromExcel)
                {
                    try
                    {
                        // Назначаем сотруднику роль, исходя из должности
                        if (employeeFromExcel.EmployeePosition == "Начальник управления")
                        {
                            employeeFromExcel.EmployeeRole = DAL.Enums.Roles.HeadOfDepartment;
                        }
                        else if (employeeFromExcel.EmployeePosition == "Заместитель начальника управления")
                        {
                            employeeFromExcel.EmployeeRole = DAL.Enums.Roles.DeputyHeadOfDepartment;
                        }
                        else
                        {
                            employeeFromExcel.EmployeeRole = DAL.Enums.Roles.Employee;
                        }

                        // Проверяем, подходит ли сотрудник к какому-то управлению
                        // Исключение для РКЦ
                        if (employeeFromExcel.EmployeeDepartment.Contains("РКЦ"))
                        {
                            var rkc = await uow.Rkcs.GetAsync(x => x.RkcName == employeeFromExcel.EmployeeDepartment);

                            if (rkc != null)
                            {
                                employeeFromExcel.DepartmentId = rkc.DepartmentId;
                            }                         
                        }
                        else
                        {
                            var department = await uow.Departments.GetAsync(x => x.DepartmentName == employeeFromExcel.EmployeeDepartment);

                            // Если подходит, то добавляем его в это управление, но: 
                            // 1. Если он уже там, то ничего не изменится
                            // 2. Если у него было другое управление, то из старого он автоматически удалится
                            if (department != null)
                            {
                                employeeFromExcel.DepartmentId = department.Id;
                            }
                            // Если не подходит, то указываем, что он не числится ни в каком управлении, но:
                            // 1. Если он и раньше не числился, то ничего не изменится
                            // 2. Если у него было управление, то он автоматически удалится из него
                            else
                            {
                                employeeFromExcel.DepartmentId = null;
                            }
                        }                     

                        // Проверяем, подходит ли сотрудник к какой-то руководящей должности
                        // Исключение для начальника юридического управления
                        if(employeeFromExcel.EmployeeDepartment == "ЮР  Юридическое управление" && employeeFromExcel.EmployeeRole == DAL.Enums.Roles.HeadOfDepartment)
                        {
                            var leadershipPosition = await uow.LeadershipPositions.GetAsync(x => x.LeadershipPositionName == "Директор по правовому обеспечению");
                            
                            if (leadershipPosition != null)
                            {
                                employeeFromExcel.LeadershipPositionId = leadershipPosition.Id;
                            }                           
                        }
                        else
                        {
                            var leadershipPosition = await uow.LeadershipPositions.GetAsync(x => x.LeadershipPositionName == employeeFromExcel.EmployeePosition);

                            // Если подходит, то добавляем его в список сотрудников этой руководящей должности, но: 
                            // 1. Если он уже там, то ничего не изменится
                            // 2. Если у него была другая руководящая должность, то из старого он автоматически удалится
                            if (leadershipPosition != null)
                            {
                                employeeFromExcel.LeadershipPositionId = leadershipPosition.Id;
                            }
                            // Если не подходит, то указываем, что он не имеет руководящей должности, но:
                            // 1. Если он и раньше не имел, то ничего не изменится
                            // 2. Если у него была руководяща должность, то он автоматически удалится из списка сотрудников этой руководящей должности
                            else
                            {
                                employeeFromExcel.LeadershipPositionId = null;
                            }
                        }
                       
                        // Пробуем найти такого пользователя в БД
                        var existingEmployee = await uow.Employees.GetAsync(x => x.EmployeeServiceNumber == employeeFromExcel.EmployeeServiceNumber);

                        // Если находим, то обновляем его в БД
                        if (existingEmployee != null)
                        {
                            existingEmployee.EmployeeName = employeeFromExcel.EmployeeName;
                            existingEmployee.EmployeePosition = employeeFromExcel.EmployeePosition;
                            existingEmployee.EmployeeDepartment = employeeFromExcel.EmployeeDepartment;
                            existingEmployee.EmployeeDivision = employeeFromExcel.EmployeeDivision;
                            existingEmployee.EmployeeSector = employeeFromExcel.EmployeeSector;

                            uow.Employees.Update(existingEmployee);
                        }
                        // Если не находим, то добавляем сотрудника в БД
                        else
                        {
                            await uow.Employees.AddAsync(employeeFromExcel);
                        }

                        await uow.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.Error($"Произошла ошибка во время работы с пользователем {employeeFromExcel.EmployeeName} : {ex.Message}. Откат всех изменений.");
                        await uow.RollbackAsync();
                    }
                }
            }
        }

        private async Task RemoveNonActiveUsers(List<Employee> employeesFromExcel)
        {
            using (var uow = new UnitOfWork(new ApplicationDbContext(_options)))
            {
                var allDbEmployees = await uow.Employees.GetAllAsync();

                foreach (var dbEmployee in allDbEmployees)
                {
                    if (!employeesFromExcel.Any(x => x.EmployeeServiceNumber == dbEmployee.EmployeeServiceNumber))
                    {
                        var nonActiveEmployee = await uow.Employees.GetAsync(x => x.Id == dbEmployee.Id);
                        uow.Employees.Remove(nonActiveEmployee);

                        await uow.CommitAsync();
                    }
                }
            }
        }
    }
}
