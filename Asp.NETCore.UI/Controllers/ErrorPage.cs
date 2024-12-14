using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.Controllers
{
	public class ErrorPage : Controller
	{
		public IActionResult Hata()
		{
			return View();
		}
	}
}
