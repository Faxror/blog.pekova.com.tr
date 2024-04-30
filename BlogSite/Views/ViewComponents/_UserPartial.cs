using BlogSite.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Views.ViewComponents
{
    public class _UserPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _UserPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
                var valuse = await _userManager.FindByNameAsync(User.Identity.Name);
                UserChangeAndViewModel userChangeAndViewModels = new UserChangeAndViewModel
                {
             
                    Image = valuse.Image,
                    NameAndSunName = valuse.NameAndSunName,

                };
                return View(userChangeAndViewModels);
             
        }
    }
}
