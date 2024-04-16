using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _Layout()
        {
            return View();
        }
    }
}
