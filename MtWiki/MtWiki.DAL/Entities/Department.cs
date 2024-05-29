using System.ComponentModel.DataAnnotations;

namespace MtWiki.DAL.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Value DepartmentName is required.")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "The Value DepartmentDescription is required.")]
        public string DepartmentDescription { get; set; }


        public int? CuratorId { get; set; }
        public Curator? Curator { get; set; }
        

        public List<Employee> Employees { get; set; } = new();
    }
}
