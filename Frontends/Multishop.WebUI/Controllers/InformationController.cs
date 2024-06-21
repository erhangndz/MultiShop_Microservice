using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Multishop.WebUI.Controllers
{
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string culture)
        {
            TempData["SelectedCulture"] = culture;

            return View("Index",culture);
        }
    }
}
