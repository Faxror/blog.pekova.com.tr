using BusinessLayer.Abstrack;
using DataAcceessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBlogService blogService;
        private readonly Context _context;
        private readonly ICommentService _commentService;

        public AdminController(IBlogService blogService, Context context, ICommentService commentService)
        {
            this.blogService = blogService;
            _context = context;
            _commentService = commentService;
        }

        public IActionResult AdminBlogList()
        {
            var blogadmin = blogService.GetListWithAuthor();
            return View(blogadmin);
        }

        public IActionResult AdminCommentList(int id)
        {
            var comment = _commentService.GetListByBlog(id);
            return View(comment);
        }

    }
}
