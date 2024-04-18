using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.ViewComponents.ProductDetails
{
    public class _ProductDetailFeature: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
