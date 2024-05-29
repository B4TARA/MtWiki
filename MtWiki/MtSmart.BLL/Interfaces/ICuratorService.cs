using MtSmart.BLL.DTO;

namespace MtSmart.BLL.Interfaces
{
    public interface ICuratorService
    {
        Task<IEnumerable<CuratorDTO>> GetAllCurators();

        Task<CuratorDTO> GetCuratorById(int curatorId);
    }
}
