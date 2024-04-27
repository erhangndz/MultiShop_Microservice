using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index(string? id)
        {
            ViewBag.id = id;
            return View();
        }

        public IActionResult ProductDetails()
        {
            return View();
        }
    }
}
