using Microsoft.AspNetCore.Mvc;
using MtSmart.BLL.DTO;
using MtSmart.BLL.Interfaces;

namespace MtWiki.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuratorController : Controller
    {
        private readonly ICuratorService _curatorService;

        public CuratorController(ICuratorService curatorService)
        {
            _curatorService = curatorService;
        }

        [HttpGet("GetAllCurators")]
        public async Task<IEnumerable<CuratorDTO>> GetAllCurators()
        {
            var allCurators = await _curatorService.GetAllCurators();

            return allCurators;
        }

        [HttpGet("GetCuratorById/{curatorId}")]
        public async Task<CuratorDTO> GetCuratorById(int curatorId)
        {
            var curatorById = await _curatorService.GetCuratorById(curatorId);

            return curatorById;
        }
    }
}
