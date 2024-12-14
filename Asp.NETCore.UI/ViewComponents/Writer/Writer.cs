using BusinessLayer.Concrete;
using DataAcessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.ViewComponents.Writer
{
    public class Writer:ViewComponent
    {
        WriterManager writerManager = new WriterManager(new WriterRepository());
        public IViewComponentResult Invoke()
        {
            var writervalues = writerManager.GetList();
            return View(writervalues);
        }
    }
}
