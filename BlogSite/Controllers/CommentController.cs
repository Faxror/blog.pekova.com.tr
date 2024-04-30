using BusinessLayer.Abstrack;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogSite.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public PartialViewResult LeaveComment()
        {

            return PartialView();
        }

        [HttpPost]
        public PartialViewResult LeaveComment(Comment comment)
        {
            _commentService.AddComment(comment);
            return PartialView();
        }
    }
}
