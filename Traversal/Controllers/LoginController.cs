using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Traversal.Models;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            var model = new UserRegisterViewModel();
            model.GenderOptions = new List<SelectListItem>()
            { 
             new SelectListItem{Value=" ",Text="Select Gender"},
             new SelectListItem{Value="Female",Text="Female"},
             new SelectListItem{Value="Male",Text="Male"},
             new SelectListItem{Value="Others",Text="Others"}
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel m)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Name = m.Name,
                    SurName = m.Surname,
                    Email = m.Email,
                    PhoneNumber = m.Phone,
                    Gender = m.Gender,
                    Age = m.Age,
                    UserName = m.Username
                };

                if (m.Password == m.ConfirmPassword)
                {
                    var result = await _userManager.CreateAsync(user, m.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("SignIn");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }

            m.GenderOptions = new List<SelectListItem>()
            {
            new SelectListItem{Value="",Text="Select Gender"},
            new SelectListItem{Value="Female",Text="Female"},
            new SelectListItem{Value="Male",Text="Male"},
            new SelectListItem{Value="Others",Text="Others"}
            };

            return View(m);
        }
        [HttpGet]
        public IActionResult SignIn()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginViewModel m)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(m.Username, m.Password, false, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile", new { area = "Member" });
                }
                else
                {
                    ModelState.AddModelError("","Invalid username or password");
                    
                    return View(m);
                }
            }
            return View(m);
        }
    }
}