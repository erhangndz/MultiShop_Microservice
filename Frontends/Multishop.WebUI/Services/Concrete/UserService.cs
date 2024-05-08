using Microsoft.Extensions.Options;
using Multishop.WebUI.Models;
using Multishop.WebUI.Services.Interfaces;
using Multishop.WebUI.Settings;

namespace Multishop.WebUI.Services.Concrete
{
    public class UserService(HttpClient _client, IOptions<ServiceApiSettings> _serviceApiSettings) : IUserService
    {
        
        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await _client.GetFromJsonAsync<UserDetailViewModel>("api/user/GetUserInfo");
        }
    }
}
