using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminLayoutSidebar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
