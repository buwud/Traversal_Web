using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            ViewBag.ToursNum = c.Destinations.Count();
            ViewBag.UsersNum = c.Users.Count();
            return View();
        }
    }
}
