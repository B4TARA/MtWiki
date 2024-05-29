using AutoMapper;
using MtSmart.BLL.DTO;
using MtSmart.BLL.Interfaces;
using MtWiki.DAL.Interfaces;

namespace MtSmart.BLL.Services
{
    public class LeadershipPositionService : ILeadershipPositionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeadershipPositionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LeadershipPositionDTO> GetLeadershipPositionById(int leadershipPositionId)
        {
            var leadershipPosition = await _unitOfWork.LeadershipPositions.GetAsync(x => x.Id == leadershipPositionId, includeProperties: "Employees");

            return _mapper.Map<LeadershipPositionDTO>(leadershipPosition);
        }
    }
}
