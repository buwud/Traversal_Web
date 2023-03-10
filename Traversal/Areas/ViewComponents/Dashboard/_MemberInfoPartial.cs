using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.ViewComponents.Dashboard
{
    [AllowAnonymous]
    public class _MemberInfoPartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _MemberInfoPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _userManager.FindByNameAsync(User.Identity.Name).Result;
            ViewBag.Name = values.Name + " " + values.SurName;
            ViewBag.Phone=values.PhoneNumber; 
            ViewBag.Email=values.Email;
            ViewBag.Location = "Turkey";
            
            return View();
        }
    }
}
