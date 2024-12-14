using DataEntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Asp.NETCore.UI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {

            _userManager = userManager;
        }
        public IActionResult RegisterIndex()
        {
            return View();
        }
         [HttpPost]
        public async Task<IActionResult> RegisterIndex(UserSignUp userSignUp)
        {
            AppUser user = new AppUser()
            {
                Email = userSignUp.Mail,
                UserName = userSignUp.UserName,
                nameSurname = userSignUp.nameSurname,
                
            };
            var result = await _userManager.CreateAsync(user,userSignUp.Password);
            if (result.Succeeded)
            {
                return RedirectToAction(" BlogIndex", "Blog"); 
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(userSignUp);
        }
    }
}
