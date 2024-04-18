using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.ViewComponents.Shop
{
    public class _ShopFilteredProductList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
