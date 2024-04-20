using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminLayoutHead:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
