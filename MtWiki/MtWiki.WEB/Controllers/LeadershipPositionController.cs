using Microsoft.AspNetCore.Mvc;
using MtSmart.BLL.DTO;
using MtSmart.BLL.Interfaces;

namespace MtWiki.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeadershipPositionController
    {
        private readonly ILeadershipPositionService _leadershipPositionService;

        public LeadershipPositionController(ILeadershipPositionService leadershipPositionService)
        {
            _leadershipPositionService = leadershipPositionService;
        }

        [HttpGet("GetDepartmentById/{leadershipPositionId}")]
        public async Task<LeadershipPositionDTO> GetLeadershipPositionById(int leadershipPositionId)
        {
            var leadershipPositionById = await _leadershipPositionService.GetLeadershipPositionById(leadershipPositionId);

            return leadershipPositionById;
        }
    }
}
