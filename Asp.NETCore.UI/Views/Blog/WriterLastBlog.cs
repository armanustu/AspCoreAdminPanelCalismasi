using BusinessLayer.Concrete;
using DataAcessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.Views.Blog
{
	public class WriterLastBlog:ViewComponent
	{
		BlogManager blogManager = new BlogManager(new BlogRepository());
		public IViewComponentResult Invoke()
		{
							
			var values = blogManager.GetListBlogByWriter(5);
			return View(values);
		}

	}
}
