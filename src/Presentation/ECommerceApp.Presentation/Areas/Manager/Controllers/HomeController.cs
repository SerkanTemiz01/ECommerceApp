using Microsoft.AspNetCore.Mvc;

namespace ECommerceApp.Presentation.Areas.Manager.Controllers
{
	[Area("Manager")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
