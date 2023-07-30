using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents.Comment
{
    public class _CommentList:ViewComponent
    {
        CommentManager _commentManager = new CommentManager(new EfCommentDal());
        private Context _context = new Context();  
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.commentCounter = _context.Comments.Where(x => x.DestinationID == id).Count();
            var values = _commentManager.TGetListWithDestinationAndUser(id);
            return View(values);
        }
    }
}