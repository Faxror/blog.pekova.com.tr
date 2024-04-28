using BlogSite.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
         return View();
        }

        [HttpGet]
        public async Task<IActionResult> MyProfiles()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserChangeAndViewModel userChangeAndViewModel = new UserChangeAndViewModel
            {
                Phone = value.Phone,
                Username = value.UserName,
                Image = value.Image,
                NameAndSunName = value.NameAndSunName,
                ShortAbout = value.ShortAbout,
                Email = value.Email,
            };
            return View(userChangeAndViewModel); 
        }
        [HttpPost]
        public async Task<IActionResult> MyProfiles(UserChangeAndViewModel userChangeAndViewModel)
        {
            if(userChangeAndViewModel.Password == userChangeAndViewModel.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Phone = userChangeAndViewModel.Phone;
                user.Email = userChangeAndViewModel.Email;
                user.NameAndSunName = userChangeAndViewModel.NameAndSunName;
                user.UserName = userChangeAndViewModel.Username;
                user.ShortAbout = userChangeAndViewModel.ShortAbout;
                user.Image = userChangeAndViewModel.Image;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userChangeAndViewModel.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(userChangeAndViewModel);
        }

    }
}
