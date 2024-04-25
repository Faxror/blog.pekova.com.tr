using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
