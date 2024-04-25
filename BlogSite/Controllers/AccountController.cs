using DataAcceessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;


namespace BlogSite.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Author p)
        {
            Context c = new Context();
            var userinfo = c.Authors.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);
            if (userinfo != null)
            {
                FormsAuthentication
            }
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
