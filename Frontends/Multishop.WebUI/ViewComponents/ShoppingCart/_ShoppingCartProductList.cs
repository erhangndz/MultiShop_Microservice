using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.ViewComponents.ShoppingCart
{
    public class _ShoppingCartProductList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
