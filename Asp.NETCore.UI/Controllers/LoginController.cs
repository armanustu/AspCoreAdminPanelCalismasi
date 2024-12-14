using DataAcessLayer.Concrete;
using DataEntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using NuGet.Protocol.Core.Types;
using NuGet.Protocol.Plugins;
using System.Security.Claims;

namespace Asp.NETCore.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context context;
        public LoginController(Context context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Writer writer)
        {

            Context context = new Context();
            var data = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);           
            if (data!=null)
            {
                //string[] roles = new string[2];
                //roles[0] = "Admin";
                //roles[1] = "Moderatör";
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,writer.WriterMail),
                   //new Claim(ClaimTypes.Role,Admin)

                };

                var useridentity = new ClaimsIdentity(claims, "Login1");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Writer");
            }


            return View();
        }
        //public async Task<IActionResult> Index()
        //{
        //    return View();
        //}            
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Login");
        }
    }
}
