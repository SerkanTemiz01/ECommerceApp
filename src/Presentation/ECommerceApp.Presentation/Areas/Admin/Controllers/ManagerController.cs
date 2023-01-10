using ECommerceApp.Application.Models.DTOs;
using ECommerceApp.Application.Models.VMs;
using ECommerceApp.Application.Services.AdminService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

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
            //if(ModelState.IsValid)
            //{
            //    await _adminService.CreateManager(addManagerDTO);
            //    return RedirectToAction(nameof(ListOfManagers));
            //}

            //return View(addManagerDTO);

            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri("https://localhost:7230/");//Api'nin senin localinde bulunan adresini ya da server adressi
                var responseTask = client.PostAsJsonAsync<AddManagerDTO>("api/Manager/PostManager", addManagerDTO);
               
                responseTask.Wait();
                var resultTask = responseTask.Result;

               
                if (resultTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(ListOfManagers));
                }
                else
                {  
                    return BadRequest();
                }
            }
        }
        public async Task<IActionResult> ListOfManagers()
        {
            //return View(await _adminService.GetManagers());
            using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7230/");//Api'nin senin localinde bulunan adresini ya da server adressi
                var responseTask = client.GetAsync("api/Manager/GetManagers");
                responseTask.Wait();
                var resultTask = responseTask.Result;

               
                if(responseTask.IsCompletedSuccessfully)
                {
                    var readTask = resultTask.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var readData = JsonConvert.DeserializeObject<List<ListOfManagerVM>>(readTask.Result);

                    return View(readData);
                }
                else
                {
                    ViewBag.EmptyList = "List in not fount";
                    return View(new List<ListOfManagerVM>());
                }
            }
           
        }
        [HttpGet]
        public async Task<IActionResult> UpdateManager(Guid id)
        {
            var updateManager = await _adminService.GetManager(id);
            return View(updateManager);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateManager(UpdateManagerDTO updateManagerDTO)
        {
           if(ModelState.IsValid)
            {
                await _adminService.UpdateManager(updateManagerDTO);
                return RedirectToAction(nameof(ListOfManagers));
            }
           return View(updateManagerDTO);
        }

        public async Task<IActionResult> DeleteManager(Guid id)
        {
            await _adminService.DeleteMAnager(id);
            return RedirectToAction(nameof(ListOfManagers));
        }
    }
}
