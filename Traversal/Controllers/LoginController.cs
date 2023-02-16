using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal.Models;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public LoginController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel m)
        {
            AppUser user = new AppUser()
            {
                 Name= m.Name,
                 SurName=m.Surname,
                 Email=m.Email,
                 PhoneNumber=m.Phone,
                 Gender=m.Gender,
                 Age=m.Age,
                 UserName=m.Username
            };

            if (m.Password == m.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(user, m.Password);

                if(result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(m);
        }
        
        public IActionResult SignIn()
        {
            return View();
        }
    }
}