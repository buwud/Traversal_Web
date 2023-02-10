using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Comment
{
    public class _CommentList:ViewComponent
    {
        CommentManager _commentManager = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            var values = _commentManager.GetComments(id);
            return View(values);
        }
    }
}