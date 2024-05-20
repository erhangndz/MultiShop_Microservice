using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.WebUI.Services.OrderServices.OrderingServices;

namespace Multishop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController(IOrderingService _orderingService) : Controller
    {
        public async Task<IActionResult> OrderList()
        {
            var values = await _orderingService.GetOrderingByUserIdAsync();
            return View(values);
        }
    }
}
