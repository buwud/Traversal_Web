using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuestController : Controller
    {
        private readonly IAppUserService _appUserService;

        public GuestController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
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
        [HttpGet]
        public IActionResult EditGuest(int id)
        {
            var values = _appUserService.TGetByID(id);
            return View(values);
        }
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
        public IActionResult GuestHistory()
        {
            _appUserService.GetList();
            return View();
        }

    }
}