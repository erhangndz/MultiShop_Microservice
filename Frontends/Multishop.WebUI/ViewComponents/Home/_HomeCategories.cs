using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeCategories: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
