using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.IdentityDtos;
using Multishop.WebUI.Services.Interfaces;

namespace Multishop.WebUI.Controllers
{
    [AllowAnonymous]
    [Route("[controller]/[action]/{id?}")]
    public class LoginController : Controller
    {
        private readonly HttpClient _client;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;
        public LoginController(HttpClient client, ILoginService loginService, IIdentityService identityService)
        {
            client.BaseAddress = new Uri("https://localhost:5001/api/");
            _client = client;
            _loginService = loginService;
            _identityService = identityService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInDto signInDto, string? returnUrl)
        {
            var result = await _identityService.SignIn(signInDto);
            if (result == true)
            {
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
            return View();
        }


    
    }
}
