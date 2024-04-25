using BusinessLayer.Abstrack;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService authorService;

        public AuthorController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AuthorList()
        {
            var authors = authorService.GetList();
            return View(authors);
        }
        [HttpGet]
        public IActionResult AddAuthor()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddAuthor(Author p)
        {
            var author = authorService.AddAuthor(p);
           return RedirectToAction("AuthorList");
        }

        [HttpGet]
        public IActionResult UpdateAuthor()
        {

            return View();
        }
        [HttpPost]
        public IActionResult UpdateAuthor(Author p)
        {
            var authorup = authorService.UpdateAuthor(p);
            return RedirectToAction("AuthorList");
        }
    }
}
