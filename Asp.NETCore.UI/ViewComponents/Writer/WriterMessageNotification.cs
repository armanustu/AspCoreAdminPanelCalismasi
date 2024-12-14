using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
