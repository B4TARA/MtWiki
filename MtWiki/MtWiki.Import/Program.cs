using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MtWiki.DAL;
using MtWiki.Import;
using NLog;

internal class Program
{
    private static void Main(string[] args)
    {
        DateTime debugToday = DateTime.Today;

        var _config = new ConfigurationBuilder().AddJsonFile("C:\\Users\\evgen\\OneDrive\\Документы\\GitHub\\MtWiki\\Configuration\\appsettings.json", optional: false, reloadOnChange: true).Build();

        var _employeessPath = _config["FilePaths:EmployeesPath"];
        var _colsArrayPath = _config["FilePaths:ColsArrayPath"];
        var _employeesImgPath = _config["FilePaths:EmployeesImgDownloadPath"];

        var _nlogConfigPath = _config["FilePaths:NLogConfigPath"];
        LogManager.Configuration = new NLog.Config.XmlLoggingConfiguration(_nlogConfigPath);
        var _logger = LogManager.GetCurrentClassLogger();

        var _dbConnectionString = _config["ConnectionStrings:WebApiDatabase"];
        var _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var _options = _optionsBuilder.UseNpgsql(_dbConnectionString).Options;

        var importer = new ExportAndImport(_options);
        importer.TransferEmployeesFromExcelToDatabase(_employeessPath, _colsArrayPath, _employeesImgPath).Wait();
    }
}