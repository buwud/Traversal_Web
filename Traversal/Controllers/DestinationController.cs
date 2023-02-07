using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal()); 
        public IActionResult Index()
        {
            var values = _destinationManager.GetList();
            return View(values);
        }
        //Verileri id ye göre buldurup taşıma işlemi gerçekleştiricez
        [HttpGet]
        public IActionResult DestinationDetails(int id)
        {
            var value = _destinationManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult DestinationDetails(Destination d)
        {

            return View();
        }

    }
}
