using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
