using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.ViewComponents.AdminDashboard
{
    public class _AdminGuideList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}