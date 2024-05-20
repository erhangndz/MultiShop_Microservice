using Microsoft.AspNetCore.Mvc;
using Multishop.WebUI.Services.Interfaces;

namespace Multishop.WebUI.Areas.User.ViewComponents.UserLayout
{
    public class _UserLayoutNavbar(IUserService _userService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            ViewBag.name = user.Name + " " + user.Surname;
            return View();
        }
    }
}
