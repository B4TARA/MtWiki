using Microsoft.AspNetCore.Mvc;
using MtSmart.BLL.DTO;
using MtSmart.BLL.Interfaces;

namespace MtWiki.WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("GetDepartmentById/{departmentId}")]
        public async Task<DepartmentDTO> GetDepartmentById(int departmentId)
        {
            var departmentById = await _departmentService.GetDepartmentById(departmentId);

            return departmentById;
        }
    }
}
