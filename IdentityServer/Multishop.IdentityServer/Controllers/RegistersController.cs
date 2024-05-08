using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Multishop.IdentityServer.Dtos;
using Multishop.IdentityServer.Models;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace Multishop.IdentityServer.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterDto registerDto)
        {
            var user = new ApplicationUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,

            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Kullanıcı Kayıt Edildi");
        }
    }
}
