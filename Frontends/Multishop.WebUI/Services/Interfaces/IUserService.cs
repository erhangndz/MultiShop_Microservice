using Multishop.WebDTO.DTOs.IdentityDtos;
using Multishop.WebUI.Models;

namespace Multishop.WebUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();

        Task<List<ResultUserDto>> GetAllUsers();
    }
}
