using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Areas.User.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
