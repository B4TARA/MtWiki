using AutoMapper;
using MtSmart.BLL.DTO;
using MtSmart.BLL.Interfaces;
using MtWiki.DAL.Interfaces;

namespace MtSmart.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DepartmentDTO> GetDepartmentById(int departmentId)
        {
            var department = await _unitOfWork.Departments.GetAsync(x => x.Id == departmentId, includeProperties: "Employees");

            return _mapper.Map<DepartmentDTO>(department);
        }
    }
}
