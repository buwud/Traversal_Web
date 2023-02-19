using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Member.Controllers
{
    public class Comment : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
