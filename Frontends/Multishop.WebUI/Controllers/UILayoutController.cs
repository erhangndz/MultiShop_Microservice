using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Controllers
{
    [AllowAnonymous]
    public class UILayoutController : Controller
    {
        public IActionResult _Layout()
        {
            return View();

        }
    }
}
