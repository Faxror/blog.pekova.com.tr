using BusinessLayer.Abstrack;
using DataAcceessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Controllers
{
    public class ContactController : Controller
    {
        private readonly Context context;
        private readonly ICommentService commentService;

        public ContactController(Context context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Contact c)
        {
            context.Contacts.Add(c);
            context.SaveChanges();
            return RedirectToAction("SendMessage");
        }

        public IActionResult MessageDetails (int id)
        {
            var getirmesaj = context.Contacts.FirstOrDefault(x => x.ContactID == id);
            return View(getirmesaj);
        }

       
    }
}
