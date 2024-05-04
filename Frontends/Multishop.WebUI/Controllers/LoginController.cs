using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.IdentityDtos;
using NuGet.DependencyResolver;

namespace Multishop.WebUI.Controllers
{
	[Route("[controller]/[action]/{id?}")]
	public class LoginController : Controller
	{
		private readonly HttpClient _client;
		public LoginController(HttpClient client)
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
		public async Task<IActionResult> Index(LoginDto loginDto)
		{
			var result = await _client.PostAsJsonAsync("logins", loginDto);
			if(result.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "About", new { area = "Admin" });
			}
			ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
			return View();
		}
	}
}
