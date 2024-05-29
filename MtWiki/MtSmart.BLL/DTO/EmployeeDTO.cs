using MtWiki.DAL.Enums;

namespace MtSmart.BLL.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string EmployeeName { get; set; }
        public Roles EmployeeRole { get; set; }
    }
}
