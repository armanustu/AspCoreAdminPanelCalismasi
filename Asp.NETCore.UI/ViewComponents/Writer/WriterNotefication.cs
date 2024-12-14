using BusinessLayer.Concrete;
using DataAcessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.ViewComponents.Writer
{
    public class WriterNotefication:ViewComponent
    {
        NotificationManager notificationManager = new NotificationManager(new NotificationRepository());
        public IViewComponentResult Invoke()
        {
            var result = notificationManager.GetList();
            return View(result);
        }
    }
}
