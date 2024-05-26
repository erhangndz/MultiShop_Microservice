
namespace Multishop.SignalRRealTimeApi.Services
{
    public class SignalRService(HttpClient _client) : ISignalRService
    {
        public async Task<int> GetMessageCountByReceiverIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<int>("https://localhost:5000/services/message/messages/GetMessageCountByReceiverId/" + id);
        }

        public async Task<int> GetPassiveCommentCountAsync()
        {
            return await _client.GetFromJsonAsync<int>("https://localhost:5000/services/comment/comments/getPassiveCommentCount"); 
        }
    }
}
