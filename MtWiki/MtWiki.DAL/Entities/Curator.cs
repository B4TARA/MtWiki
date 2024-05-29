using System.ComponentModel.DataAnnotations;

namespace MtWiki.DAL.Entities
{
    public class Curator
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Value CuratorServiceNumber is required.")]
        public int CuratorServiceNumber { get; set; }

        [Required(ErrorMessage = "The Value CuratorName is required.")]
        public string CuratorName { get; set; }

        [Required(ErrorMessage = "The Value CuratorPosition is required.")]
        public string CuratorPosition { get; set; }


        public List<Department> SubordinateDepartments { get; set; } = new();
        public List<LeadershipPosition> SubordinateLeadershipPositions { get; set; } = new();
    }
}
