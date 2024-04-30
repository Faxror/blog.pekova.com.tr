using BusinessLayer.Abstrack;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Views.ViewComponents
{
    public class _CategoryByBlogDetailsPartial : ViewComponent
    {    
        private readonly ICategoryService categoryService;

        public _CategoryByBlogDetailsPartial(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var category = categoryService.GetList();
            return View(category);
        }
    }
}
