using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.ViewComponents.AdminDashboard
{
    public class _AdminDashStatistic:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
