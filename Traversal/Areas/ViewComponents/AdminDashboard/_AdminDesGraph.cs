using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.ViewComponents.AdminDashboard
{
    public class _AdminDesGraph:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
