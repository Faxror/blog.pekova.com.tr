using BusinessLayer.Abstrack;
using DataAcceessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Views.ViewComponents
{
    public class _OtherPostByWriter : ViewComponent
    {
        Context c = new Context();
        private readonly IBlogService blogService;

        public _OtherPostByWriter(Context c, IBlogService blogService)
        {
            this.c = c;
            this.blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
           var blogauthorid = c.Blogs.ToList().Where(x => x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();
           var authorblog =  blogService.GetBlogByAuthors(blogauthorid);
            return View(authorblog);
        }
    }
}
