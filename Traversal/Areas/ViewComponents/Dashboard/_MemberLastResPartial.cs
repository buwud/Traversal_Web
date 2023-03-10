using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.ViewComponents.Dashboard
{
    [AllowAnonymous]
    public class _MemberLastResPartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        ReservationManager _reservationManager = new ReservationManager(new EfReservationDal());

        public _MemberLastResPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueList = _reservationManager.GetListAll(values.Id).TakeLast(3).ToList();

            return View(valueList);
        }
    }
}
