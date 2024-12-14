using BusinessLayer.Concrete;
using DataAcessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.Area.Admin.Controllers
{
    [Area("Admin")]//bu bir deneme12
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        CategoryManager categoryManager = new CategoryManager(new CategoryRepository());
   
        //[HttpGet]
        //public JsonResult GetData()
        //{

        //    var List = categoryManager.;
        //    return Json(List);
        //}

    }
}
