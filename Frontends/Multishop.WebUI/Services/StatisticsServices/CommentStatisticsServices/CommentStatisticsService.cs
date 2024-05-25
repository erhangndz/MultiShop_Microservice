
namespace Multishop.WebUI.Services.StatisticsServices.CommentStatisticsServices
{
    public class CommentStatisticsService(HttpClient _client) : ICommentStatisticsService
    {
        public async Task<int> GetActiveCommentCountAsync()
        {
           return await _client.GetFromJsonAsync<int>("comments/getActiveCommentCount");
        }

        public async Task<int> GetPassiveCommentCountAsync()
        {
            return await _client.GetFromJsonAsync<int>("comments/getPassiveCommentCount");
        }

        public async Task<int> GetTotalCommentCountAsync()
        {
            return await _client.GetFromJsonAsync<int>("comments/getTotalCommentCount");
        }
    }
}
