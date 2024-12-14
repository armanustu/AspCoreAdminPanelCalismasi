using BusinessLayer.Concrete;
using DataAcessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.Views.Category
{
	public class Categories:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			CategoryManager categoryManager = new CategoryManager(new CategoryRepository());
			var values = categoryManager.GetList();
			return View(values);	
		}
		
	}
}
