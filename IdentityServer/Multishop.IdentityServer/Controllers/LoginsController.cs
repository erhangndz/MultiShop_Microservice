using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Multishop.IdentityServer.Dtos;
using Multishop.IdentityServer.Models;
using Multishop.IdentityServer.Tools;
using System.Threading.Tasks;

namespace Multishop.IdentityServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginsController : ControllerBase
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;


        public LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
		public async Task<IActionResult> Login(LoginDto loginDto)
		{
			var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password,false,false);
			
			if (result.Succeeded)
			{
                var user =await  _userManager.FindByNameAsync(loginDto.UserName);
                var model = new GetCheckAppUserViewModel();
				model.UserName= loginDto.UserName;
				model.Id = user.Id;
				var token = JwtTokenGenerator.GenerateToken(model);
				return Ok(token);
			}
			return BadRequest("Kullanıcı adı veya şifre yanlış");
		}
	}
}
