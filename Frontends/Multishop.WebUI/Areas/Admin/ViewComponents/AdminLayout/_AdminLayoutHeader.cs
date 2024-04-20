using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeader:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
