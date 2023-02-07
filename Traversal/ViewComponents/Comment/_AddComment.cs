using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Comment
{
    public class _AddComment:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
