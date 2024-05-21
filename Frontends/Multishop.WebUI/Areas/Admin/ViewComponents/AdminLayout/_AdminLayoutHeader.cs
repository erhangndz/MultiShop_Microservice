using Microsoft.AspNetCore.Mvc;
using Multishop.WebUI.Services.Interfaces;

namespace Multishop.WebUI.Areas.Admin.ViewComponents.AdminLayout
{
    public class _AdminLayoutHeader(IUserService _userService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            ViewBag.name = user.Name + " " + user.Surname;
            return View();
        }
    }
}
