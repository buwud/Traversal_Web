using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Traversal.Areas.Member.Models;
using Traversal.Models;
using System.Diagnostics;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            UserEditViewModel m = new UserEditViewModel();
            m.GenderOptions = new List<SelectListItem>()
            {
                new SelectListItem{Value=" ",Text="Select Gender"},
                new SelectListItem{Value="Female",Text="Female"},
                new SelectListItem{Value="Male",Text="Male"},
                new SelectListItem{Value="Others",Text="Others"}
            };

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (ModelState.IsValid)
            {
                m.Name = values.Name;
                m.Surname = values.SurName;
                m.Email = values.Email;
                m.Username = values.UserName;
                m.Phone = values.PhoneNumber;
                m.Gender = values.Gender;
                m.Age = values.Age;
            }

            try
            {
                return View(m);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel m)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (m.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(m.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/MemberImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await m.Image.CopyToAsync(stream);
                user.ImageURL = imageName;
            }
            user.Name = m.Name;
            user.SurName = m.Surname;
            user.Email = m.Email;
            user.PhoneNumber = m.Phone;
            user.Gender = m.Gender;
            user.Age = m.Age;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, m.Password);
            
            var result = await _userManager.UpdateAsync(user);


            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            else
            {
                // add error messages to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
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
        }
    }
}