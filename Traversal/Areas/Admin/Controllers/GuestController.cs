using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuestController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public GuestController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var values = _appUserService.GetList();
            return View(values);
        }
        public IActionResult DeleteGuest(int id)
        {
            var value = _appUserService.TGetByID(id);
            _appUserService.TDelete(value);
            string returnUrl = Request.Headers["Referer"].ToString();
            return Redirect(returnUrl);
        }
        [Route("EditGuest")]
        [HttpGet]
        public IActionResult EditGuest(int id)
        {
            var values = _appUserService.TGetByID(id);
            return View(values);
        }
        [Route("EditGuest")]
        [HttpPost]
        public IActionResult EditGuest(AppUser a)
        {
            _appUserService.TUpdate(a);
            return RedirectToAction("Index");
        }
        public IActionResult GuestComments()
        {
            _appUserService.GetList();
            return View();
        }
        public IActionResult GuestHistory(int id)
        {
            var values = _reservationService.GetListAll(id);
            return View(values);
        }

    }
}