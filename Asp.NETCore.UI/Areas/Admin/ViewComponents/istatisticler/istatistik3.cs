using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using DataAcessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.Areas.Admin.ViewComponents.istatisticler
{
    public class istatistik3:ViewComponent
    {
        AdminManager adminmanager = new AdminManager(new AdminRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.Admin = adminmanager.GetList().Where(x=>x.AdminID==1).Select(y=>y.Name).FirstOrDefault();
            //ViewBag.Resim = context.Admins.Where(X => X.AdminID==1).Select(x=>x.ImageUrl).FirstOrDefault();
            ViewBag.AdminResim = adminmanager.GetList().Where(x => x.AdminID == 1).Select(y => y.ImageUrl).FirstOrDefault();

            return View();
        }
    }
}
