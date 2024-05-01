using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error1(int code)
        {
            return View();
        }

        [Route("Error/500")]
        public IActionResult Page500()
        {
            try
            {
                throw new Exception("Bu bir örnek istisna.");

            }
            catch (Exception ex)
            {
                // Hata işleme kodlarını burada yerine getirin
                // Örneğin, hatayı bir günlüğe kaydetme, istisna mesajını görüntüleme vb.

                return View();
            }
        }
    }
}
