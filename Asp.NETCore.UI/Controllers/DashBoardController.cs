using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using DataAcessLayer.Repository;
using DataEntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Asp.NETCore.UI.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {

            Context context = new Context();
            ViewBag.ToplamBlogsCount = context.Blogs.Count();
            ViewBag.ToplamCategori = context.Categories.Count();
            ViewBag.ToplamSizinBlogSayınız = context.Blogs.Where(x => x.BlogID == 1).Count();
            return View();
        }
		CommentManager commentManager = new CommentManager(new CommentRepository());
		Context context = new Context();
		public IActionResult Test()
        {
           
            var mail = User.Identity.Name;
            int WriterID = context.Writers.Where(c => c.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            var comment =(from m in commentManager.GetList()
                         where m.WriterID==WriterID
                         select new Comment
                         {
                               CommentContent=m.CommentContent,
                               CommentUserName=m.CommentUserName,
                         }).ToList();   
            return View(comment);
        }
    }
}
