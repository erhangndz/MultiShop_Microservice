using Microsoft.AspNetCore.Mvc;

namespace Multishop.WebUI.ViewComponents.Contact
{
    public class _ContactInfo:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
