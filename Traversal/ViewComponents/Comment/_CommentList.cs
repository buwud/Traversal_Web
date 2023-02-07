using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Comment
{
    public class _CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
