using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.ViewComponents.UILayout
{
    public class _UILayoutScripts:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
