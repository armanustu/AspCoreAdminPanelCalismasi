using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using DataAcessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.ViewComponents.Comment
{
	public class CommentNotification : ViewComponent
	{
		CommentManager commentManager = new CommentManager(new CommentRepository());
		Context context = new Context();
		public IViewComponentResult Invoke()
		{
			
			var mail = User.Identity.Name;
			int WriterID = context.Writers.Where(c => c.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
			var comment = commentManager.GetList().Where(emp => emp.WriterID==WriterID).ToList();			
			return View(comment);
		}
	}
}
