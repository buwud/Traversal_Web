using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.ViewComponents.Dashboard
{
    public class _MemberAnnouncementPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
