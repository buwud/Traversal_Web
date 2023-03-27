using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGuide() 
        {

            return View();
        }
        [HttpPost]  
        public IActionResult AddGuide(Guide g)
        {
            _guideService.TInsert(g);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var value = _guideService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditGuide(Guide g)
        {
            _guideService.TUpdate(g);
            return RedirectToAction("Index");
        }

        public IActionResult EnableThis(int id)
        {

            return RedirectToAction("Index");
        }

    }
}
