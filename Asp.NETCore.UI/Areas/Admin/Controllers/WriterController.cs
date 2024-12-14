using Asp.NETCore.UI.Areas.Admin.Models;
using Asp.NETCore.UI.Models;
using Asp.NETCore.UI.ViewComponents.Writer;
using BusinessLayer.Concrete;
using DataAcessLayer.Abstract;
using DataAcessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace Asp.NETCore.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        private readonly IWriterDAL _writerdal;

        public WriterController(IWriterDAL writerdal)
        {
            _writerdal = writerdal;
        }

        public IActionResult Index()
        {
           
            return View();            
        }
        Context context = new Context();
        public IActionResult WriterGetList()
        {

           var jsonwriters = JsonConvert.SerializeObject(_writerdal.GetAll().ToList());
                   
           return Json(jsonwriters);
        }
        public IActionResult WriterGet(int id)
        {
            var yazar = context.Writers.Where(x => x.WriterID == id).FirstOrDefault();
            var jsonwriters1 = JsonConvert.SerializeObject(yazar);
            return Json(jsonwriters1);
        }
        public IActionResult WriterSearch(string id)
        {
            var yazarlar = context.Writers.ToList();
            yazarlar = yazarlar.Where(w => w.WriterName.IndexOf(id, StringComparison.InvariantCultureIgnoreCase) != -1).ToList();
            var jsonObjectYazarlar = JsonConvert.SerializeObject(yazarlar);
            return Json(jsonObjectYazarlar);
        }
       
    }
}
