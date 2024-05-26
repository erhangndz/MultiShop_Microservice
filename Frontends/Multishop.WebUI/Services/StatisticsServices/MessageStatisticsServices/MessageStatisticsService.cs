
namespace Multishop.WebUI.Services.StatisticsServices.MessageStatisticsServices
{
    public class MessageStatisticsService(HttpClient _client) : IMessageStatisticsService
    {
        public async Task<int> GetTotalMessageCountAsync()
        {
            return await _client.GetFromJsonAsync<int>("messages/GetMessageCount");
        }
    }
}
