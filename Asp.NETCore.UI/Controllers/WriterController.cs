using Asp.NETCore.UI.Models;
using BusinessLayer.Concrete;
using DataAcessLayer.Concrete;
using DataAcessLayer.Repository;
using DataEntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Security.Claims;

namespace Asp.NETCore.UI.Controllers
{
    public class WriterController : Controller
    {
        private readonly Context context;
        public WriterController(Context context)
        {
            this.context = context;
        }
        [Authorize]
        public IActionResult Index()
        {

            var mail = User.Identity.Name;
            int WriterID = context.Writers.Where(x => x.WriterMail == mail).Select(m => m.WriterID).FirstOrDefault();
            var writervalues = writerManager.BlogGetByID(WriterID);
            return View(writervalues);
        }
        WriterManager writerManager = new WriterManager(new WriterRepository());
        public IActionResult WriterEditProfile(int id)
        {
            var writervalues = writerManager.BlogGetByID(id);
            return View(writervalues);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            bool durum = writerManager.WriterUpdate(writer);
            if (durum == true)
            {
                ViewBag.Status = true;
            }
            return View();
        }

        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage addProfileImage)
        {
            Writer writer = new Writer();
            if (addProfileImage.WriterImage != null)
            {
                var extension = Path.GetExtension(addProfileImage.WriterImage.FileName);
                var nevigame = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", nevigame);
                var stream = new FileStream(location, FileMode.Create);
                addProfileImage.WriterImage.CopyTo(stream);
                writer.WriterImage = nevigame;
                writer.WriterName = addProfileImage.WriterName;
                writer.WriterMail = addProfileImage.WriterMail;
                writer.WriterStatus = addProfileImage.WriterStatus;
                writer.WriterPassword = addProfileImage.WriterPassword;
                writer.RepeatPassword = addProfileImage.RepeatPassword;
                writer.WriterAbout = addProfileImage.WriterAbout;

                writerManager.WriterAdd(writer);
            }
            return View();
        }
        public IActionResult WriterAdd()
        {
            return View();
        }
        public PartialViewResult PartialNavBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Writer");
        }
    }
}
