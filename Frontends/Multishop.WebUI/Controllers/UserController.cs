using Microsoft.AspNetCore.Mvc;
using Multishop.WebUI.Services.Interfaces;

namespace Multishop.WebUI.Controllers
{
    public class UserController(IUserService _userService) : Controller
    {
   
        public async Task<IActionResult> Index()
        {
            var values = await _userService.GetUserInfo();
            return View(values);
        }


        
    }
}
