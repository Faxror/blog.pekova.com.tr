using BlogSite.Models;
using BusinessLayer.Abstrack;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Views.ViewComponents
{
    public class _CommentListPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentListPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var yorumlarigetir = _commentService.GetListByBlog(id);
            return View(yorumlarigetir);
        }

    }
}
