using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
