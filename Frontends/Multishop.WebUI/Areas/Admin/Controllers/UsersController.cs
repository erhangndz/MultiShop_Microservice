using Microsoft.AspNetCore.Mvc;
using Multishop.WebUI.Services.CargoServices.CargoCustomerServices;
using Multishop.WebUI.Services.Interfaces;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class UsersController(IUserService _userService,ICargoCustomerService _cargoCustomerService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _userService.GetAllUsers();
            return View(values);
        }

        public async Task<IActionResult> AddressDetailByUserId(string id)
        {
            var values = await _cargoCustomerService.GetDetailsByUserIdAsync(id);
            return View(values);
        }
    }
}
