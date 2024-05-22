using Microsoft.Extensions.Options;
using Multishop.WebDTO.DTOs.IdentityDtos;
using Multishop.WebUI.Models;
using Multishop.WebUI.Services.Interfaces;
using Multishop.WebUI.Settings;

namespace Multishop.WebUI.Services.Concrete
{
    public class UserService(HttpClient _client) : IUserService
    {
        public async Task<List<ResultUserDto>> GetAllUsers()
        {
            return await _client.GetFromJsonAsync<List<ResultUserDto>>("/api/users/GetAllUsers");
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await _client.GetFromJsonAsync<UserDetailViewModel>("/api/users/GetUserInfo");
          
        }
    }
}
