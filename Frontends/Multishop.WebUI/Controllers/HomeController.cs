using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
