using Asp.NETCore.UI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Asp.NETCore.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            List<CategoryClass> list = GetList();
            return Json(new { jsonList = list });
        }

        public static List<CategoryClass>GetList()
        {

            List<CategoryClass> lst = new List<CategoryClass>();
            lst.Add(new CategoryClass {
                CategoryCount = 1,
                CategoryName = "teknoloji"

            });
            lst.Add(new CategoryClass
            {
                CategoryCount = 2,
                CategoryName = "yazilim"
            });
            return lst;
              
        }
    }
}
