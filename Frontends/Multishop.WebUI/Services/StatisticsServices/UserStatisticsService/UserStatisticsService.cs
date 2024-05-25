
namespace Multishop.WebUI.Services.StatisticsServices.UserStatisticsService
{
    public class UserStatisticsService(HttpClient _client) : IUserStatisticsService
    {
        public async Task<int> GetUserCountAsync()
        {
            return await _client.GetFromJsonAsync<int>("/api/Statistics/GetUserCount");
        }
    }
}
