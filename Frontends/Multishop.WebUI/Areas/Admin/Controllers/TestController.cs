using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
