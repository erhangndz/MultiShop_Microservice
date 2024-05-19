using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [AllowAnonymous]
    public class MyOrderController : Controller
    {
        public IActionResult OrderList()
        {
            return View();
        }
    }
}
