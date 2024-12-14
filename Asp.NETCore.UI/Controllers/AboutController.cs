using BusinessLayer.Concrete;
using DataAcessLayer.Abstract;
using DataAcessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.Controllers
{
	public class AboutController : Controller
	{
		IAboutDAL _aboutDAL;
        public AboutController(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        public IActionResult Index()
		{ 
			var aboutvalues = _aboutDAL.GetAll();
			return View(aboutvalues);
		}
		public PartialViewResult SocialMedya()
		{
			return PartialView();
		}
	}
}
