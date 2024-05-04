using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        
        {
            var user = User.Claims;
            int x;
            return View();
        }
    }
}
