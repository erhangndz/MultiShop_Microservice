using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.ViewComponents.UILayout
{
    public class _UILayoutHead:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
