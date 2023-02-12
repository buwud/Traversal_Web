using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    public class CommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EfCommentDal());
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.CommentDate= Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            p.CommentState = true;
            //p.DestinationID = 2;
            _commentManager.TInsert(p);
            return RedirectToAction("Index", "Destination");
        }
    }
}