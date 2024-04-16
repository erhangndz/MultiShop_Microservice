using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.ViewComponents.UILayout
{
    public class _UILayoutTopbar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
