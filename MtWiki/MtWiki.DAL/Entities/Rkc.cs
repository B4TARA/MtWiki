using System.ComponentModel.DataAnnotations;

namespace MtWiki.DAL.Entities
{
    public class Rkc
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Value RkcName is required.")]
        public string RkcName { get; set; }


        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
