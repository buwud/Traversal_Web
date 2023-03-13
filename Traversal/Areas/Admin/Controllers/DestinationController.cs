using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

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
            _destinationManager.TInsert(d);
            return RedirectToAction("Index");
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