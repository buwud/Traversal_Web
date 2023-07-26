using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Destination")]
    //[Route("Admin/[controller]/[action]")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _destinationService.GetList();
            return View(values);
        }
        //Addition
        [Route("AddDestination")]
        [HttpGet]
        public IActionResult AddDestination() 
        {
            return View();
        }
        [Route("AddDestination")]
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
                _destinationService.TInsert(d);
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
            var value = _destinationService.TGetByID(id);
            _destinationService.TDelete(value);
            //bulunuduğum sayfanın url ini alıyor
            string returnUrl = Request.Headers["Referer"].ToString();
            return Redirect(returnUrl);
        }
        //Edition
        [Route("EditDestination/{id}")]
        [HttpGet]
        public IActionResult EditDestination(int id)
        {
            var value = _destinationService.TGetByID(id);
            return View(value);
        }
        [Route("EditDestination/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditDestination(Destination d)
        {
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    foreach (var error in errors)
                    {
                        var errorMessage = error.ErrorMessage;
                    }
                }
                return View(d);
            }
            var value = _destinationService.TGetByID(d.DestinationID);
            value.StayTime = d.StayTime;
            value.City = d.City;
            value.Price = d.Price;
            value.Description = d.Description;
            value.Capacity = d.Capacity;
            value.Status = d.Status;
            value.Details = d.Details;
            value.Details1 = d.Details1;


            if (d.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(d.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/AdminImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await d.Image.CopyToAsync(stream);
                value.ImageS = imageName;
            }

            if (d.Image1 != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(d.Image1.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/AdminImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await d.Image1.CopyToAsync(stream);
                value.Image1S = imageName;
            }

            if (d.CoverImage != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(d.CoverImage.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/AdminImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await d.CoverImage.CopyToAsync(stream);
                value.CoverImageS = imageName;
            }

            _destinationService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}