using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.OrderDtos.AddressDtos;
using Multishop.WebUI.Services.Interfaces;
using Multishop.WebUI.Services.OrderServices.AddressServices;

namespace Multishop.WebUI.Controllers
{
	
	public class OrderController(IAddressService _addressService,IUserService _userService) : Controller
	{
		
		public async Task<IActionResult> Index()
		{
            var user = await _userService.GetUserInfo();
            ViewBag.city = user.City;
            ViewBag.name = user.Name;
            ViewBag.surname = user.Surname;
            ViewBag.email = user.Email;
			ViewBag.userid = user.Id;
            return View();
		}


		[HttpPost]
		public async Task<IActionResult> CreateAddress(CreateAddressDto createAddressDto)
		{
			
			await _addressService.CreateAddressAsync(createAddressDto);
			return NoContent();
		}
	}
}
