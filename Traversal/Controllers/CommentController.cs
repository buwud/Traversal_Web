using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Controllers
{
    [Route("Comment")]
    public class CommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EfCommentDal());

        [HttpGet]
        [Route("AddComment/{id}")]
        public async Task<PartialViewResult> AddComment(int id)
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.CommentDate= Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            p.CommentState = true;
            _commentManager.TInsert(p);
            return RedirectToAction("Index", "Destination");
        }
    }
}