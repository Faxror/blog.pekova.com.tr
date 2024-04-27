using BlogSite.Models;
using DataAcceessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;



namespace BlogSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, true);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginViewModel.Username);
                if (user.EmailConfirmed == true)
                {
                    return RedirectToAction("Index", "User");
                }
                else if (user.EmailConfirmed == false)
                {
                    ViewBag.Error = "Lütfen e posta addresinizi doğrulayınız";
                    return View(loginViewModel);
                }
            }
            ViewBag.Error = "Kullanıcı adı veya şifre yanlış.";
            return View();
        }
        [HttpGet]
        public IActionResult Register() 
        { 
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModels registerViewModels)
        {
            if(ModelState.IsValid)
            { 
                Random random = new Random();
                int code;
                code = random.Next(1000, 100000);
                AppUser appUser = new AppUser()
                {
                    UserName = registerViewModels.Username,
                    NameAndSunName = registerViewModels.NameandSurname,
                    Email = registerViewModels.Email,
                    Phone = registerViewModels.Phone,
                    ConfirimCode = code,
                };
                var result = await _userManager.CreateAsync(appUser, registerViewModels.Password);
                if (result.Succeeded)
                {
                    SmtpClient smtpClient = new SmtpClient("mt-prime-win.guzelhosting.com", 587);
                    
       
                    smtpClient.Credentials = new NetworkCredential("information@pekova.com.tr", "2e3Gd9j3*");
                    smtpClient.EnableSsl = true;
                    string recipientEmail = $"{appUser.Email}";
                    string emailTitle = "Yaz Blog Onay Kodu";
                    string emailBody = $"Merhaba Kayıt İşlemini Bitirmek İçin   kodunuz {code}";

                    MailMessage mail = new MailMessage( "information@pekova.com.tr", recipientEmail, emailTitle, emailBody);

                    await smtpClient.SendMailAsync(mail);
                    TempData["Mail"] = registerViewModels.Email;
              
                    return RedirectToAction("EmailConfirmed", "Account");
                }
               else
                {
                    foreach( var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult EmailConfirmed() 
         {
            var value = TempData["Mail"];
            ViewBag.v = value;
                return View();
         }
        [HttpPost]
        public async Task<IActionResult> EmailConfirmed(ConfirmViewModel confirmViewModel)
        {
            var user = await _userManager.FindByEmailAsync(confirmViewModel.Mail);
            if(user.ConfirimCode == confirmViewModel.ConfirmCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Login", "Account");
            }
            
            if (user == null)
            {
               
                ViewBag.Error = "E-posta adresiyle ilişkilendirilmiş kullanıcı bulunamadı.";
                return View(confirmViewModel);
            } 
            else if (user.ConfirimCode != confirmViewModel.ConfirmCode)
            {
                ViewBag.Error = "Doğrulama kodu hatalı.";
                return View(confirmViewModel);
            }
            return View();
        }

    }
}
