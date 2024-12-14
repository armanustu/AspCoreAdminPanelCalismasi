using BusinessLayer.Concrete;
using DataAcessLayer.Abstract;
using DataAcessLayer.Concrete;
using DataAcessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.Controllers
{
    public class ChartController : Controller
    {
        Context context = new Context();
        BlogManager blogManager = new BlogManager(new BlogRepository());
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetData()
        {           
            var mail = User.Identity.Name;
			int WriterID = context.Writers.Where(x => x.WriterMail == mail).Select(m => m.WriterID).FirstOrDefault();
            var blog = blogManager.GetListBlogByWriter(WriterID).ToList();
            return Json(blog);
        }
    }
}
