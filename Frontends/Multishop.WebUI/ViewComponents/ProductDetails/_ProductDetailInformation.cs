using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.ViewComponents.ProductDetails
{
    public class _ProductDetailInformation:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
