using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Areas.User.ViewComponents.UserLayout
{
    public class _UserLayoutScripts:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
