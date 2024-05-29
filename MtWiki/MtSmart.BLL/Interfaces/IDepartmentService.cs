using MtSmart.BLL.DTO;

namespace MtSmart.BLL.Interfaces
{
    public interface IDepartmentService
    {
        Task<DepartmentDTO> GetDepartmentById(int departmentId);
    }
}
