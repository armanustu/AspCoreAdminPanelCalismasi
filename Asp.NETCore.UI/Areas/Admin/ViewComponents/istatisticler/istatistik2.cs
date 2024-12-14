using DataAcessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.Areas.Admin.ViewComponents.istatisticler
{
   
    public class istatistik2:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.SoneklenenBlog = context.Blogs.OrderByDescending(x => x.BlogID).Select(x => x.BlogTitle).Take(1).FirstOrDefault();
            return View();
        }
       
    }
}
