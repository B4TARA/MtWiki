namespace MtSmart.BLL.DTO
{
    public class CuratorDTO
    {
        public int Id { get; set; }
        public int IndexNumber { get; set; }

        public string CuratorName { get; set; }
        public string CuratorPosition { get; set; }


        public string? CuratorImagePath { get; set; }


        public List<DepartmentDTO> SubordinateDepartments { get; set; } = new();
        public List<LeadershipPositionDTO> SubordinateLeadershipPositions { get; set; } = new();
    }
}
