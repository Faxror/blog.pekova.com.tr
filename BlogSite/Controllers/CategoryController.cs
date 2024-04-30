using BusinessLayer.Abstrack;
using EntityLayer.Concrete;
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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = categoryService.GetListByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Category category) 
        {
            categoryService.EditCategory(category);
            return RedirectToAction("CategoryList", "Admin");
        }


        public IActionResult Delete(int id)
        {
            categoryService.DeleteCategory(id);
            return RedirectToAction("CategoryList", "Admin");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            categoryService.AddCategory(category);

            return RedirectToAction("CategoryList", "Admin");
        }
    }
}
