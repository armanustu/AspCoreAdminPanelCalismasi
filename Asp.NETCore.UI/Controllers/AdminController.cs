using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
