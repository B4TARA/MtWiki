using System.ComponentModel.DataAnnotations;

namespace MtWiki.DAL.Entities
{
    public class LeadershipPosition
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Value LeadershipPositionName is required.")]
        public string LeadershipPositionName { get; set; }

        public int? CuratorId { get; set; }
        public Curator? Curator { get; set; }

        public List<Employee> Employees { get; set; } = new();
    }
}
