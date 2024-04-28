using BlogSite.Models;
using BusinessLayer.Abstrack;
using BusinessLayer.Concrete;
using DataAcceessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Controllers
{

    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IBlogService blogService;

        private readonly Context context;

        public UserController(UserManager<AppUser> userManager, IBlogService blogService, Context context)
        {
            _userManager = userManager;
            this.blogService = blogService;
            this.context = context;
        }

        [Authorize]        [HttpGet]
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

        public IActionResult MyBlogs(int id)
        {

            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID = context.Authors.Where(x => x.Mail == usermail).Select(y => y.AuthorID).FirstOrDefault();
            ViewBag.v = writerID;
            var values = blogService.GetListWithCategoryByWriter(writerID);
            return View(values);
        }


        [HttpGet]
        public IActionResult AddWriterBlog()
        {
            CategoryManager categoryManager = new CategoryManager(new CategoryRepository(context));
            List<SelectListItem> values = (from x in categoryManager.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();

            AuthorManager AuthorManager = new AuthorManager(new AuthorRepository(context));
            List<SelectListItem> valuess = (from x in AuthorManager.GetList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.s3 = values;
            ViewBag.a3 = valuess;
            return View();
        }

        [HttpPost]
        public IActionResult AddWriterBlog(Blog p)
        {

            blogService.AddBlog(p);
            return RedirectToAction("MyBlogs");
        }
        

        [HttpGet]
        public IActionResult UpdateWriterBlog(int id)
        {
            CategoryManager categoryManager = new CategoryManager(new CategoryRepository(context));
            List<SelectListItem> values = (from x in categoryManager.GetList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();

            AuthorManager AuthorManager = new AuthorManager(new AuthorRepository(context));
            List<SelectListItem> valuess = (from x in AuthorManager.GetList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.s5 = values;
            ViewBag.a5 = valuess;
            var value = blogService.GetBlogByİD(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateWriterBlog(Blog p)
        {

            blogService.Update(p);
            return RedirectToAction("MyBlogs");
        }
        public IActionResult DeleteWriterBlog(int id)
        {
            blogService.Delete(id);
            return RedirectToAction("MyBlogs");
        }

    }
}
