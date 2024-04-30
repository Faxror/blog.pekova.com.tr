using BusinessLayer.Abstrack;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult CategoryByBlogDetails()
        {
            var category = categoryService.GetList();
            return PartialView(category);
        }
    }
}
