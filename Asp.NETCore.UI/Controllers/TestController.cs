using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using DataAcessLayer.Repository;
using DataEntityLayer.Concrete;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp.NETCore.UI.Controllers
{
    public class TestController : Controller
    {


        BlogManager blogManager = new BlogManager(new BlogRepository());
        public IActionResult Index3()
        {

           var  value = (from m in blogManager.GetList()
                                                  select new Blog
                                                  {
                                                       BlogTitle=  m.BlogTitle,
                                                       BlogSayisi=  m.BlogSayisi
                                                  }).GroupBy(m => m.WriterID).ToList();
            
            return View(value);
        }
        
    }
}
