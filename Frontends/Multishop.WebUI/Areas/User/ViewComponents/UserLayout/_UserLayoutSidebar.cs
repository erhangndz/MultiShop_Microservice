using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Areas.User.ViewComponents.UserLayout
{
    public class _UserLayoutSidebar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
