using AutoMapper;
using MtSmart.BLL.DTO;
using MtSmart.BLL.Interfaces;
using MtWiki.DAL.Interfaces;

namespace MtSmart.BLL.Services
{
    public class CuratorService : ICuratorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CuratorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CuratorDTO>> GetAllCurators()
        {
            var allCurators = await _unitOfWork.Curators.GetAllAsync();

            return _mapper.Map<IEnumerable<CuratorDTO>>(allCurators);
        }

        public async Task<CuratorDTO> GetCuratorById(int curatorId)
        {
            var curator = await _unitOfWork.Curators.GetAsync(x => x.Id == curatorId, includeProperties: new string[] { "SubordinateDepartments", "SubordinateLeadershipPositions" });

            return _mapper.Map<CuratorDTO>(curator);
        }
    }
}
