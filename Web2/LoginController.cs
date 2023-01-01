using Microsoft.AspNetCore.Mvc;

namespace WebProje1.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
