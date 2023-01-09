using ECommerceApp.Application.Models.DTOs;
using ECommerceApp.Application.Models.VMs;
using ECommerceApp.Application.Services.AdminService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public ManagerController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet("Get")]

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
        public async Task<ActionResult<UpdateManagerDTO>> GetManager([FromRoute]Guid id)
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
        public async Task<ActionResult> CreateManager([FromForm]AddManagerDTO addManagerDTO)
        {
            await _adminService.CreateManager(addManagerDTO);
            //try
            //{
            //   // addManagerDTO.UploadPath = formFile;
            //    await _adminService.CreateManager(addManagerDTO);
            //}
            //catch (Exception)
            //{
            //    return BadRequest();
            //}
            return Ok(addManagerDTO);
        }
    }
}
