using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
