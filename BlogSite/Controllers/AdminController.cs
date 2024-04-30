using BusinessLayer.Abstrack;
using DataAcceessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBlogService blogService;
        private readonly Context _context;
        private readonly ICommentService _commentService;
        private readonly IAuthorService authorService;

        public AdminController(IBlogService blogService, Context context, ICommentService commentService, IAuthorService authorService)
        {
            this.blogService = blogService;
            _context = context;
            _commentService = commentService;
            this.authorService = authorService;
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

        public IActionResult AuthorList(Author p)
        {
            var authors = authorService.GetList();
            return View(authors);
        }

    }
}
