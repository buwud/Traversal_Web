using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.ViewComponents.Dashboard
{
    public class _MemberHeadingPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}