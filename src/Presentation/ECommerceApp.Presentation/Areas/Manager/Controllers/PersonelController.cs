using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Presentation.Areas.Manager.Controllers
{
    public class PersonelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
