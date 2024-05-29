using AutoMapper;
using MtSmart.BLL.DTO;
using MtWiki.DAL.Entities;

namespace MtSmart.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Curator, CuratorDTO>();
            CreateMap<Department, DepartmentDTO>();
            CreateMap<LeadershipPosition, LeadershipPositionDTO>();
            CreateMap<Employee, EmployeeDTO>();
        }
    }
}
