using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using DataAcessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Asp.NETCore.UI.Areas.Admin.ViewComponents.istatisticler
{
    public class istatistic:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            BlogManager blogManager = new BlogManager(new BlogRepository());
            ViewBag.BlogCount = blogManager.GetList().Count();
            ViewBag.Yorumlar= context.Comments.Count();
            ViewBag.Contact = context.Contacts.Count();
            string api = "fe723fa787533753426213415eb77a3e";
            string connection ="https://api.openweathermap.org/data/2.5/weather?q=izmir&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument document = XDocument.Load(connection);
            ViewBag.Wheateherdocumentasyon=document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            return View();
        }
    }
}
