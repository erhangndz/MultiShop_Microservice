using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeSpecialOffer:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
