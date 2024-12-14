using BusinessLayer.Concrete;
using DataAcessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.Area.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        BlogManager blogManager = new BlogManager(new BlogRepository());
        public IActionResult Index()
        {
            var result = blogManager.GetList();
            return View(result);
        }
    }
}
