using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Areas.User.ViewComponents.UserLayout
{
    public class _UserLayoutNavbar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
