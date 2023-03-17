using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());

        public IActionResult Index()
        {
            var values = _destinationManager.GetList();
            return View(values);
        }
        //Addition
        [HttpGet]
        public IActionResult AddDestination() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddDestination(Destination d)
        {
            AddDestinationValidator validationRules=new AddDestinationValidator();
            ValidationResult result = validationRules.Validate(d);
            if (d.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(d.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/AdminImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await d.Image.CopyToAsync(stream);
                d.ImageS = imageName;
            }
            if (d.Image1 != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(d.Image1.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/AdminImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await d.Image1.CopyToAsync(stream);
                d.Image1S = imageName;
            }
            if (d.CoverImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(d.CoverImage.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/AdminImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await d.CoverImage.CopyToAsync(stream);
                d.CoverImageS = imageName;
            }

            if (result.IsValid)
            {
                d.Status = true;
                _destinationManager.TInsert(d);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(d);
            }
        }
            
        //Deletion
        public IActionResult DeleteDestination(int id)
        {
            var value = _destinationManager.TGetByID(id);
            _destinationManager.TDelete(value);
            //bulunuduğum sayfanın url ini alıyor
            string returnUrl = Request.Headers["Referer"].ToString();
            return Redirect(returnUrl);
        }
        //Edition
        [HttpGet]
        public IActionResult EditDestination(int id)
        {
            var value = _destinationManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditDestination(Destination d)
        {
            _destinationManager.TUpdate(d);
            return RedirectToAction("Index");
        }
    }
}