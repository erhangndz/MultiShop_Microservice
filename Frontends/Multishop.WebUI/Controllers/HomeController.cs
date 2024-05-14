using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            

            return View();
        }
    }
}
