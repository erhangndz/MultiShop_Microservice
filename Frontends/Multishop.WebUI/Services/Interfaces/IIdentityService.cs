using Multishop.WebDTO.DTOs.IdentityDtos;

namespace Multishop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {

        Task<bool> SignIn(SignInDto signInDto);

        Task<bool> GetRefreshToken();
    }
}
