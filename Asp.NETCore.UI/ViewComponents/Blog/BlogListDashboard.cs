using BusinessLayer.Concrete;
using DataAcessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.ViewComponents.Blog
{
    public class BlogListDashboard:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new BlogRepository());
        public IViewComponentResult Invoke()
        {
            var values = blogManager.GetListBlogWithCategory();
            return View(values);
        }
    }
}
