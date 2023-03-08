using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.ViewComponents.Dashboard
{
    public class _MemberHeadingPartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _MemberHeadingPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var value = _userManager.FindByNameAsync(User.Identity.Name).Result;
            ViewBag.Name = value.Name + " " + value.SurName;

            return View();
        }
    }
}