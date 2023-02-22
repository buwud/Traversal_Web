using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Traversal.Areas.Member.Models;
using Traversal.Models;

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
            
            m.Name = values.Name;
            m.Surname = values.SurName;
            m.Email = values.Email;
            m.Username = values.UserName;
            m.Phone = values.PhoneNumber;
            m.Gender = values.Gender;
            m.Age = values.Age;
            return View(m);
        }
    }   
}