using ECommerceApp.Application.Models.DTOs;
using ECommerceApp.Application.Models.VMs;
using ECommerceApp.Application.Services.AdminService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System;
using System.Text;
using System.Net.Http.Headers;
using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Cake.Core.IO;
using System.IO;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Components.Forms;

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
        public async Task<IActionResult> AddManager([FromForm] AddManagerDTO addManagerDTO)
        {
			if (ModelState.IsValid)
			{
                var apiAddManagerDTO = await _adminService.GetApiManagerDTO(addManagerDTO);
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri("https://localhost:7230/");

					var responseTask =await client.PostAsJsonAsync<ApiAddManagerDTO>("api/Manager/PostManager", apiAddManagerDTO);

					if (responseTask.IsSuccessStatusCode)
					{
						return RedirectToAction(nameof(ListOfManagers));
					}
					else
					{
						return BadRequest();
					}
				}
			}
			else
			{
				return BadRequest();
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
