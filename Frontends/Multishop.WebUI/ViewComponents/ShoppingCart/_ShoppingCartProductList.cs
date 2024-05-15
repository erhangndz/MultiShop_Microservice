using Microsoft.AspNetCore.Mvc;
using Multishop.WebUI.Services.BasketServices;

namespace Multishop.WebUI.ViewComponents.ShoppingCart
{
    public class _ShoppingCartProductList(IBasketService _basketService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _basketService.GetBasketAsync();
            return View(values);
        }
    }
}
