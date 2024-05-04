using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.IdentityDtos;
using System.Text.Json;

namespace Multishop.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly HttpClient _client;

		public RegisterController(HttpClient client)
		{
            client.BaseAddress = new Uri("https://localhost:5001/api/");
			_client = client;
		}

		[HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            if (registerDto.Password == registerDto.ConfirmPassword)
            {

            
            var result = await _client.PostAsJsonAsync("registers", registerDto);
            if(result.IsSuccessStatusCode)
            {
				return RedirectToAction("Index", "Login");
			}
				var errors = await result.Content.ReadFromJsonAsync<List<ErrorDto>>();
				errors.ForEach(e =>
				{
					ModelState.AddModelError("", e.Description);
				});

			}

            return View();
           
        }
    }
}
