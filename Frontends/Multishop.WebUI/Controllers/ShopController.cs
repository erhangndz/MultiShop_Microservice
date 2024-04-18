using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductDetails()
        {
            return View();
        }
    }
}
