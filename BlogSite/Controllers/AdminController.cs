using BlogSite.Models;
using BusinessLayer.Abstrack;
using DataAcceessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBlogService blogService;
        private readonly Context _context;
        private readonly ICommentService _commentService;
        private readonly IAuthorService authorService;
        private readonly ICategoryService categoryService;
        private readonly RoleManager<AppRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        public AdminController(IBlogService blogService, Context context, ICommentService commentService, IAuthorService authorService, ICategoryService categoryService, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            this.blogService = blogService;
            _context = context;
            _commentService = commentService;
            this.authorService = authorService;
            this.categoryService = categoryService;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult AdminBlogList()
        {
            var blogadmin = blogService.GetListWithAuthor();
            return View(blogadmin);
        }

        public IActionResult AdminCommentList(int id)
        {
            var comment = _commentService.GetListByBlog(id);
            return View(comment);
        }

        public IActionResult AuthorList(Author p)
        {
            var authors = authorService.GetList();
            return View(authors);
        }

        public IActionResult CategoryList()
        {
            var categories = categoryService.GetList();
            return View(categories);
        }

        public IActionResult AdminContactList ()
        {
            var sa = _context.Contacts.ToList();
            return View(sa);
        }

        public IActionResult RolList()
        {
            var valuse = roleManager.Roles.ToList();
            return View(valuse);
        }

        [HttpGet]
        public IActionResult AddRol()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddRol(RolViewModel rolViewModel)
        {
            if(ModelState.IsValid) {

                AppRole appRole = new AppRole()
                {
                    Name = rolViewModel.Name,
                };

                var result = await roleManager.CreateAsync(appRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("RolList", "Admin");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateRol(int id)
        {
             var valusee2 = roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RolUpdateViewModel model = new RolUpdateViewModel()
            {
                ID = valusee2.Id,
                name = valusee2.Name,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRol(RolUpdateViewModel rolUpdateViewModel)
        {
            var valuese = roleManager.Roles.Where(c => c.Id == rolUpdateViewModel.ID).FirstOrDefault();
            valuese.Name = rolUpdateViewModel.name;
            var result =  await roleManager.UpdateAsync(valuese);
            if (result.Succeeded)
            {
                return RedirectToAction("RolList", "Admin");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("",item.Description);
            }
            return View();
        }


        public async Task<IActionResult> DeleteRol(int id)
        {
            var valuese = roleManager.Roles.FirstOrDefault(x => x.Id == id);
       
            var result = await roleManager.DeleteAsync(valuese);
            if (result.Succeeded)
            {
                return RedirectToAction("RolList", "Admin");
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View();
        }


        public IActionResult UserRolList()
        {
            var valuese = userManager.Users.ToList();
            return View(valuese);
        }

        [HttpGet]
        public async Task<IActionResult> AssingRole(int id)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == id);
            var role = roleManager.Roles.ToList();

            TempData["UserID"] = user.Id;
            var userRoles =await userManager.GetRolesAsync(user);
            List<RoleAssingnViewModel> model = new List<RoleAssingnViewModel>();
            foreach (var item in role) 
            {
                RoleAssingnViewModel model2 = new RoleAssingnViewModel();
                model2.RoleID = item.Id;
                model2.Name = item.Name;
                model2.Exists = userRoles.Contains(item.Name);
                model.Add(model2);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssingRole(List<RoleAssingnViewModel> roleAssingnViewModels)
        {
            var userId = (int)TempData["userId"];
            var user = userManager.Users.FirstOrDefault(x=>x.Id == userId);
            foreach (var item in roleAssingnViewModels)
            {
                if (item.Exists)
                {
                    await userManager.AddToRoleAsync(user, item.Name);
                }
                else
                {
                    await userManager.RemoveFromRoleAsync(user, item.Name);
                }
            }
            return RedirectToAction("UserRolList", "Admin");
        }
    }
}
