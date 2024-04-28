using BusinessLayer.Abstrack;
using DataAcceessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class WriterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IBlogService blogService;

        private readonly Context context;

        public WriterController(UserManager<AppUser> userManager, IBlogService blogService, Context context)
        {
            _userManager = userManager;
            this.blogService = blogService;
            this.context = context;
        }


     
    }
}
