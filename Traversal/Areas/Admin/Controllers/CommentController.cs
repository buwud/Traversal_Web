using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values = _commentService.TGetListWithDestinations();
            return View(values);
        }
        public IActionResult DeleteComment(int id)
        {
            var value = _commentService.TGetByID(id);
            _commentService.TDelete(value);
            string url = Request.Headers["Referer"].ToString();
            return Redirect(url);
        }
    }
}
