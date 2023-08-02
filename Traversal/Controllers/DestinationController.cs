using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _destinationManager.GetList();
            return View(values);
        }
        //Verileri id ye göre buldurup taşıma işlemi gerçekleştiricez
        [HttpGet]
        public async Task<IActionResult> DestinationDetails(int id)
        {
            var userVal = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userID = userVal.Id;
            ViewBag.Id = id;
            var value = _destinationManager.TGetDestinationWithGuide(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult DestinationDetails(Destination d)
        {
            return View();
        }
    }
}