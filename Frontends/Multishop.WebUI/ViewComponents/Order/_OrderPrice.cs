using Microsoft.AspNetCore.Mvc;
using Multishop.WebUI.Services.BasketServices;

namespace Multishop.WebUI.ViewComponents.Order
{
    public class _OrderPrice(IBasketService _basketService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var basket = await _basketService.GetBasketAsync();
            return View(basket);
        }
    }
}
