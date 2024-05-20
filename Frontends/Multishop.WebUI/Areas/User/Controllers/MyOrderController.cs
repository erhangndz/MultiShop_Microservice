using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.WebUI.Services.OrderServices.OrderDetailServices;
using Multishop.WebUI.Services.OrderServices.OrderingServices;

namespace Multishop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MyOrderController(IOrderingService _orderingService,IOrderDetailService _orderDetailService) : Controller
    {
        public async Task<IActionResult> OrderList()
        {
            var values = await _orderingService.GetOrderingByUserIdAsync();
            return View(values);
        }

        public async Task<IActionResult> OrderDetails(int id)
        {
            var values = await _orderDetailService.GetOrderDetailByOrderingIdAsync(id);
            return View(values);
        }
    }
}
