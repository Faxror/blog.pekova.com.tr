using BlogSite.Models;
using BusinessLayer.Abstrack;
using BusinessLayer.Concrete;
using DataAcceessLayer.Abstrack;
using DataAcceessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using static DataAcceessLayer.Concrete.BlogRepository;

namespace BlogSite.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;
        private readonly Context _context;

        public BlogController(IBlogService blogService, Context context)
        {
            this.blogService = blogService;
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index(int? pageNumber)
        {

            int page = pageNumber ?? 1;
            int pageSize = 3;
            int offset = (page - 1) * pageSize;
            try
            {
                var latestPost = blogService.List()
                    .OrderByDescending(z => z.BlogID)
                    .FirstOrDefault(x => x.CategoryID == 1);
                var latestPost2 = blogService.List()
                                   .OrderByDescending(z => z.BlogID)
                                   .FirstOrDefault(x => x.CategoryID == 2);
                var latestPost3 = blogService.List()
                                   .OrderByDescending(z => z.BlogID)
                                   .FirstOrDefault(x => x.CategoryID == 3);
                var latestPost4 = blogService.List()
                                   .OrderByDescending(z => z.BlogID)
                                   .FirstOrDefault(x => x.CategoryID == 4);

                if (latestPost != null)
                {
                    ViewBag.post1 = latestPost.BlogTıtle;
                    ViewBag.post1Image = latestPost.BlogImage;
                    ViewBag.post1Date = latestPost.BlogTime;
                }
                else
                {
                    ViewBag.post1 = "";
                    ViewBag.post1Image = "";
                    ViewBag.post1Date = "";
                }
                if (latestPost2 != null)
                {
                    ViewBag.post2 = latestPost2.BlogTıtle;
                    ViewBag.post2Image = latestPost2.BlogImage;
                    ViewBag.post2Date = latestPost2.BlogTime;
                }
                else
                {
                    ViewBag.post2 = "";
                    ViewBag.post2Image = "";
                    ViewBag.post2Date = "";
                }
                if (latestPost3 != null)
                {
                    ViewBag.post3 = latestPost3.BlogTıtle;
                    ViewBag.post3Image = latestPost3.BlogImage;
                    ViewBag.post3Date = latestPost3.BlogTime;
                }
                else
                {
                    ViewBag.post3 = "";
                    ViewBag.post3Image = "";
                    ViewBag.post3Date = "";
                }
                if (latestPost4 != null)
                {
                    ViewBag.post4 = latestPost4.BlogTıtle;
                    ViewBag.post4Image = latestPost4.BlogImage;
                    ViewBag.post4Date = latestPost4.BlogTime;
                }
                else
                {
                    ViewBag.post4 = "";
                    ViewBag.post4Image = "";
                    ViewBag.post4Date = "";
                }



                int totalcount = _context.Blogs.Count();
                var totalPages = (int)Math.Ceiling((double)totalcount / pageSize);
                if(!pageNumber.HasValue || page < 1 || page > totalPages)
                {
                    return RedirectToAction("Index", new { pageNumber = 1 });
                    
                }

                bool isLastPage = page == totalPages;
                ViewBag.IsLastPage = isLastPage;

                var firstPage = 1;

                bool isFirstPage = page == firstPage;
                ViewBag.isFirstPage = isFirstPage;

                var paged = blogService.GetBlogWithAuthors(pageNumber);
                PagedResult<BlogWithAuthors> pagedResult = new PagedResult<BlogWithAuthors>(paged, paged.Count, page, pageSize, totalcount);
                // var getallblog2 = blogService.GetListWithAuthor();
                return View(pagedResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata" + ex.Message);

                return View("Error");
            }





            
        }

        public PartialViewResult BlogList()
        {
             var getallblog = blogService.GetListWithAuthor();
            return PartialView(getallblog);
        }

        public IActionResult BlogDetails(int id)
        {

            var blogWithAuthor = blogService.GetBlogsWhit(id);
            return View("BlogDetails", blogWithAuthor);

        }

       public PartialViewResult FeuturedPost ()
        {
            ViewBag.FeuturedPost = "a";
            return PartialView();
        }

       public IActionResult AdminBlogList()
        {
            var blogadmin = blogService.GetListWithAuthor();
            return View(blogadmin);
        }

       [HttpGet]
       public IActionResult AddBlog()
        {
            CategoryManager categoryManager = new CategoryManager(new CategoryRepository(_context));
            List<SelectListItem> values = (from x in categoryManager.GetList() select new SelectListItem 
            { 
             Text = x.CategoryName,
             Value = x.CategoryID.ToString()
            }).ToList();

            AuthorManager AuthorManager = new AuthorManager(new AuthorRepository(_context));
            List<SelectListItem> valuess = (from x in AuthorManager.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.AuthorName,
                                               Value = x.AuthorID.ToString()
                                           }).ToList();
            ViewBag.s = values;
            ViewBag.a = valuess;
            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(Blog p)
        {

            blogService.AddBlog(p);
            return RedirectToAction("AdminBlogList");
        }

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            CategoryManager categoryManager = new CategoryManager(new CategoryRepository(_context));
            List<SelectListItem> values = (from x in categoryManager.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();

            AuthorManager AuthorManager = new AuthorManager(new AuthorRepository(_context));
            List<SelectListItem> valuess = (from x in AuthorManager.GetList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.s2 = values;
            ViewBag.a2 = valuess;
            var value = blogService.GetBlogByİD(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateBlog(Blog p)
        {

            blogService.Update(p);
            return RedirectToAction("AdminBlogList");
        }
        public IActionResult DeleteBlog(int id)
        {
            blogService.Delete(id);
            return RedirectToAction("AdminBlogList");
        }

    }
}
