using BusinessLayer.Abstract;
using BusinessLayer.Validations;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }
        [Route("")]
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
        public async Task<IActionResult> AddGuide(GuideEditViewModel gm, Guide g)
        {
            var guideModel = new GuideEditViewModel();

            guideModel.Name = g.Name;
            guideModel.TwitterURL = g.TwitterURL;
            guideModel.InstagramURL = g.InstagramURL;
            guideModel.ImageURL = g.Image;

            if (guideModel.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(guideModel.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/MemberImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await guideModel.Image.CopyToAsync(stream);
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
        [Route("EditGuide")]
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var value = _guideService.TGetByID(id);
            return View(value);
        }
        [Route("EditGuide")]
        [HttpPost]
        public async Task<IActionResult> EditGuide(GuideEditViewModel gm, Guide g)
        {
            var guideModel = new GuideEditViewModel();

            guideModel.Name = g.Name;
            guideModel.TwitterURL = g.TwitterURL;
            guideModel.InstagramURL = g.InstagramURL;
            guideModel.ImageURL = g.Image;

            if (guideModel.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(guideModel.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/MemberImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await guideModel.Image.CopyToAsync(stream);
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

        public IActionResult EnableThis(int id)
        {

            return RedirectToAction("Index");
        }
    }
}
