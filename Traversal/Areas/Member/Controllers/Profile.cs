using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Member.Controllers
{
    public class Profile : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
