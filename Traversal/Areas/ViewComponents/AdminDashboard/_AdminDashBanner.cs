using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.ViewComponents.AdminDashboard
{
    public class _AdminDashBanner:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
