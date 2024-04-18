using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeProducts:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
