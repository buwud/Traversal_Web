using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.ViewComponents.Dashboard
{
    public class _MemberInfoPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
