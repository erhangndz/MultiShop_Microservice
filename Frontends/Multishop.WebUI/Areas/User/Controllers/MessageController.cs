using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Areas.User.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
