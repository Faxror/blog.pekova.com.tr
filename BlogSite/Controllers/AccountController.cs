using BlogSite.Models;
using DataAcceessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;



namespace BlogSite.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly Context context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, Context context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.context = context;
        }
        [AllowAnonymous]
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
                    if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("AdminBlogList", "Admin");
                    }
                    else if (User.IsInRole("Yazar"))
                    {
                        return RedirectToAction("MyProfiles", "User");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Blog");
                    }
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

                Author author = new Author() 
                { 
                 AuthorName = registerViewModels.NameandSurname,
                 AuthorImage = registerViewModels.Image,
                 Mail = registerViewModels.Email,
                 Phone = registerViewModels.Phone,
                 ShortAbout = registerViewModels.ShortAbout,
                 AuthorAbout = registerViewModels.About,
                 

                };
                context.Authors.Add(author);
                context.SaveChanges();
                AppUser appUser = new AppUser()
                {
                    UserName = registerViewModels.Username,
                    NameAndSunName = registerViewModels.NameandSurname,
                    Email = registerViewModels.Email,
                    Phone = registerViewModels.Phone,
                    About = registerViewModels.About,
                    ShortAbout = registerViewModels.ShortAbout,
                    Image = registerViewModels.Image,
                    AuthorID = author.AuthorID,
                    ConfirimCode = code,
                };
                
                var result = await _userManager.CreateAsync(appUser, registerViewModels.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, "Member");

                    SmtpClient smtpClient = new SmtpClient("mt-prime-win.guzelhosting.com", 587);
                    smtpClient.Credentials = new NetworkCredential("information@pekova.com.tr", "2e3Gd9j3*");
                    smtpClient.EnableSsl = true;

                    string recipientEmail = $"{appUser.Email}";

                 
                    string emailTitle = "Yaz Blog Onay Kodu";

                
                    string confirmationLink = $"{Url.Action("EmailConfirmed", "Account", new { email = appUser.Email, code = code }, protocol: HttpContext.Request.Scheme)}";

                    string emailBody = $@"<p>Merhaba,</p>
                          <p>Kayıt İşlemini Bitirmek İçin kodunuz: {code}.</p>
                          <p>Lütfen onaylamak için aşağıdaki bağlantıya tıklayın:</p>
                          <p><a href=""{confirmationLink}"">{confirmationLink}</a></p>";

                    MailMessage mail = new MailMessage("information@pekova.com.tr", recipientEmail, emailTitle, emailBody);

                    
                    mail.IsBodyHtml = true;

                    await smtpClient.SendMailAsync(mail);

           
                    TempData["Mail"] = appUser.Email;

               
                    return RedirectToAction("Login", "Account");
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
        public async Task<IActionResult> EmailConfirmed(string email, int code)
        {
            if (email == null || code == null)
            {
                return RedirectToAction("Error", "Home"); 
            }

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                ViewBag.Error = "E-posta adresiyle ilişkilendirilmiş kullanıcı bulunamadı.";
                return View(new ConfirmViewModel { Mail = email, ConfirmCode = code });
            }

            if (user.ConfirimCode != code)
            {
                ViewBag.Error = "Doğrulama kodu hatalı.";
                return View(new ConfirmViewModel { Mail = email, ConfirmCode = code });
            }

      
            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Login", "Account");
        }


        public async Task<IActionResult> logOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
