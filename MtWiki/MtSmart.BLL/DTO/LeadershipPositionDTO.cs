namespace MtSmart.BLL.DTO
{
    public class LeadershipPositionDTO
    {
        public int Id { get; set; }

        public string LeadershipPositionName { get; set; }

        public List<EmployeeDTO> Employees { get; set; } = new();
    }
}
