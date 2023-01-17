using ECommerceApp.Application.Models.DTOs;
using ECommerceApp.Application.Models.VMs;
using ECommerceApp.Application.Services.AdminService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public ManagerController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet("Get")]

        [HttpGet("GetManagers")]
        public async Task<ActionResult<List<ListOfManagerVM>>> GetAllManagers()
        {
            var managers = await _adminService.GetManagers();
            if (managers == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(managers);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UpdateManagerDTO>> GetManager([FromRoute] Guid id)
        {
            var manager = await _adminService.GetManager(id);
            if (manager == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(manager);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UpdateManagerDTO>> DeleteManager([FromRoute] Guid id)
        {

            if (id == Guid.Empty)
            {
                return NotFound();
            }
            else
            {
                await _adminService.DeleteMAnager(id);
                return Ok();
            }
        }
        [HttpPost]
        [Route("PostManager")]
        public async Task<ActionResult> CreateManager(ApiAddManagerDTO apiAddManagerDTO)
        {
            if(ModelState.IsValid) 
            {
				await _adminService.CreateManager(apiAddManagerDTO);
                return Ok(apiAddManagerDTO);
			}
            else     
            return BadRequest(ModelState);
        }
    }
}
