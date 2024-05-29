namespace MtSmart.BLL.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }

        public string DepartmentName { get; set; }

        public string DepartmentDescription { get; set; }

        public List<EmployeeDTO> Employees { get; set; } = new();
    }
}
