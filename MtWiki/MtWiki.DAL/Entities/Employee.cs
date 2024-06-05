using MtWiki.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace MtWiki.DAL.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Value EmployeeServiceNumber is required.")]
        public int EmployeeServiceNumber { get; set; }

        [Required(ErrorMessage = "The Value EmployeeName is required.")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "The Value EmployeeName is required.")]
        public string EmployeePosition { get; set; }

        [Required(ErrorMessage = "The Value EmployeeDivision is required.")]
        public string EmployeeDivision { get; set; }

        [Required(ErrorMessage = "The Value EmployeeDepartment is required.")]
        public string EmployeeDepartment { get; set; }

        [Required(ErrorMessage = "The Value EmployeeSector is required.")]
        public string EmployeeSector { get; set; }

        [Required(ErrorMessage = "The Value EmployeeRole is required.")]
        public Roles EmployeeRole { get; set; }

        public string? EmployeeImagePath { get; set; }


        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }


        public int? LeadershipPositionId { get; set; }
        public LeadershipPosition? LeadershipPosition { get; set; }
    }
}
