using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.Controllers
{
    public class HomeController(HttpClient _client) : Controller
    {
        public async Task<IActionResult> Index()
        {
            

            return View();
        }
    }
}
