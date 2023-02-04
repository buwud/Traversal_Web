using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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
            //fbfghfgh
        }
    }
}
