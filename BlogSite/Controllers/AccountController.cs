using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register() 
        { 
            return View(); 
        }  

        public IActionResult ForgetPassword() 
         {
                return View();
         }
        
    }
}
