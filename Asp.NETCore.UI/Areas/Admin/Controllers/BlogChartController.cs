using BusinessLayer.Concrete;
using DataAcessLayer.Abstract;
using DataAcessLayer.Concrete;
using DataAcessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BlogChartController : Controller//https://localhost:58802/Admin/BlogChart/Index
    {
		Context context = new Context();
		BlogManager blogManager = new BlogManager(new BlogRepository());      
        public BlogChartController()
        {
				
        }
        public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public JsonResult GetData()
		{
			//var mail = User.Identity.Name;
			string mail = "arman@hotmail.com";
			int WriterID = context.Writers.Where(x => x.WriterMail == mail).Select(m => m.WriterID).FirstOrDefault();
			var blog = blogManager.GetListBlogByWriter(WriterID).ToList();
			return Json(blog);
		}
	}
}
