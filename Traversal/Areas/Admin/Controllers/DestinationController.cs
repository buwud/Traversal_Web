using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        public IActionResult AddDestination(Destination d)
        {
            AddDestinationValidator validationRules=new AddDestinationValidator();
            ValidationResult result = validationRules.Validate(d);
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
        [HttpGet]
        public IActionResult DeleteDestination(int id)
        {
            var value = _destinationManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult DeleteDestination(Destination d)
        {
            _destinationManager.TDelete(d);
            return RedirectToAction("Index");
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