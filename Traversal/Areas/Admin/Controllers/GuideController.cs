using BusinessLayer.Abstract;
using BusinessLayer.Validations;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GuideController(IGuideService guideService, IWebHostEnvironment webHostEnvironment)
        {
            _guideService = guideService;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _guideService.GetList();
            return View(values);
        }
        [Route("AddGuide")]
        [HttpGet]
        public IActionResult AddGuide() 
        {

            return View();
        }
        [Route("AddGuide")]
        [HttpPost]  
        public async Task<IActionResult> AddGuide(IFormFile image, Guide g)
        {
            if (image != null)
            {
                var extension = Path.GetExtension(image.FileName);
                var imageName = Guid.NewGuid().ToString() + extension;
                var saveLocation = Path.Combine(_webHostEnvironment.WebRootPath, "MemberImages", imageName);
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                g.Image = imageName;
            }
            if (ModelState.IsValid)
            {
                g.Status = true;
                _guideService.TInsert(g);
                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("EditGuide/{id}")]
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var value = _guideService.TGetByID(id);
            return View(value);
        }
        [Route("EditGuide/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditGuide(Guide g, IFormFile? image)
        {
            var value = _guideService.TGetByID(g.GuideID);

            
            if (image != null)
            {
                var extension = Path.GetExtension(image?.FileName);
                var imageName = Guid.NewGuid().ToString() + extension;
                var saveLocation = Path.Combine(_webHostEnvironment.WebRootPath, "MemberImages", imageName);
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }
                value.Image = imageName;
            }
                
            if (ModelState.IsValid)
            {
                g.Image = value.Image;
                g.Status = true;
                _guideService.TUpdate(g);
                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("DeleteGuide/{id}")]
        public IActionResult DeleteGuide(int id)
        {
            var value = _guideService.TGetByID(id);
            _guideService.TDelete(value);
            return RedirectToAction("Index");
        }
        [Route("ChangeToFalse/{id}")]
        public IActionResult ChangeToFalse(int id)
        {
            _guideService.TChangeToFalseGuide(id);
            return RedirectToAction("Index");
        }
        [Route("ChangeToTrue/{id}")]
        public IActionResult ChangeToTrue(int id)
        {
            _guideService.TChangeToTrueGuide(id);
            return RedirectToAction("Index");
        }
    }
}
