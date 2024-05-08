using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            

            return View();
        }
    }
}
