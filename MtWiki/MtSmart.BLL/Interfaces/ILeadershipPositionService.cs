using MtSmart.BLL.DTO;

namespace MtSmart.BLL.Interfaces
{
    public interface ILeadershipPositionService
    {
        Task<LeadershipPositionDTO> GetLeadershipPositionById(int leadershipPositionId);
    }
}
