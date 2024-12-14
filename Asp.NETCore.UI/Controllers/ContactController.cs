using BusinessLayer.Concrete;
using DataAcessLayer.Abstract;
using DataAcessLayer.Repository;
using DataEntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NETCore.UI.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		
		ContactManager contactManager = new ContactManager(new ContactRepository());
		[HttpPost]
		public IActionResult Index(Contact contact)
		{
			contact.ContactDate = DateTime.Now;
			contact.ContactStatus = true;
			contactManager.ContactAdd(contact);

			ViewBag.status = true;
			return View();
		} 

	}
}
