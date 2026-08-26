using Microsoft.AspNetCore.Mvc;

namespace TopFilms.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
