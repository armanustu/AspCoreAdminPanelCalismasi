using BusinessLayer.Concrete;
using DataAcessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.Controllers
{
    public class NotificatificationController : Controller
    {


        NotificationManager notificationManager = new NotificationManager(new NotificationRepository());
        public IActionResult Index()
        {
            var notificationresult = notificationManager.GetList();
            return View(notificationresult);
        }
    }
}
