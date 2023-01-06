using ECommerceApp.Application.Models.DTOs;
using ECommerceApp.Application.Services.AdminService;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManagerController : Controller
    {
        private readonly IAdminService _adminService;
        public ManagerController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddManager()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddManager(AddManagerDTO addManagerDTO)
        {
            if(ModelState.IsValid)
            {
                await _adminService.CreateManager(addManagerDTO);
                return RedirectToAction(nameof(ListOfManagers));
            }
         
            return View(addManagerDTO);
        }
        public async Task<IActionResult> ListOfManagers()
        {
            return View(await _adminService.GetManagers());
        }
        
    }
}
