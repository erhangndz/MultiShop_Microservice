using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
 
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DiscountCouponController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
