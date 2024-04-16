using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeCarousel:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
