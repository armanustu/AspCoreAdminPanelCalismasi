using BusinessLayer.Concrete;
using DataAcessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.ViewComponents.Category
{
    public class CategoryListDashBoard:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryManager categoryManager = new CategoryManager(new CategoryRepository());
            var categoryvalues = categoryManager.GetList();
            return View(categoryvalues);
        }
    }
}
