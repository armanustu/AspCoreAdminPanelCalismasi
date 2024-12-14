
using BusinessLayer.Concrete;
using DataAcessLayer.Abstract;
using DataAcessLayer.Repository;
using DataEntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new CommentRepository());
        public IActionResult Comments()
        {
            //var values=commentManager.GetByID(id);
            //ViewBag.Data = values;
            return View();
        }
        public IActionResult CommentAdd(Comment comment)
        {
           
            comment.Commentstatus = true;
            comment.CommentDate = DateTime.Now;
			commentManager.CommentAdd(comment);
			return View(comment);
        }
    }
}
