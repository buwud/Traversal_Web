using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
            //hata koduna göre döndürme işlemleri yapılabilir
        {

            return View();
        }
    }
}
