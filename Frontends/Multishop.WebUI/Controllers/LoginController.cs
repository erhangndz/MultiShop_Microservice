using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.IdentityDtos;
using Multishop.WebUI.Models;
using Multishop.WebUI.Services;
using Multishop.WebUI.Services.Interfaces;
using NuGet.DependencyResolver;
using NuGet.Protocol;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace Multishop.WebUI.Controllers
{
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
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var result = await _client.PostAsJsonAsync("logins", loginDto);
            if (result.IsSuccessStatusCode)
            {
                var id = _loginService.GetUserId;
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);
                    var claims = token.Claims.ToList();

                    if (tokenModel.Token != null)
                    {
                        claims.Add(new Claim("multishoptoken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction("Index", "Home");

                    }


                }

                return View();
            }
            ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış");
            return View();
        }


        //[HttpGet]
        //public IActionResult SignIn()
        //{
        //    return View();
        //}

        //[HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            signInDto.UserName = "Ali01";
            signInDto.Password = "Password12*";
                await _identityService.SignIn(signInDto);
            return RedirectToAction("Index", "Home");
        }
    }
}
