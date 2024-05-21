using Multishop.WebDTO.DTOs.MessageDtos;
using Multishop.WebUI.Services.Interfaces;

namespace Multishop.WebUI.Services.MessageServices
{
    public class MessageService(HttpClient _client) : IMessageService
    {
        public async Task CreateMessageAsync(CreateMessageDto message)
        {
            await _client.PostAsJsonAsync("messages", message);
        }

        public async Task DeleteMessageAsync(int id)
        {
            await _client.DeleteAsync("messages/" + id);
        }

        public async Task<List<ResultMessageDto>> GetAllMessagesAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultMessageDto>>("messages");
        }

        public async Task<List<ResultMessageDto>> GetInboxMessagesAsync(string id)
        {
            return await _client.GetFromJsonAsync<List<ResultMessageDto>>("messages/getInbox/"+id);
        }

        public async Task<UpdateMessageDto> GetMessageByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateMessageDto>("messages/" + id);
        }

        public async Task<List<ResultMessageDto>> GetSentBoxMessagesAsync(string id)
        {
            return await _client.GetFromJsonAsync<List<ResultMessageDto>>("messages/getSentbox/" + id);
        }

        public async Task UpdateMessageAsync(UpdateMessageDto message)
        {
            await _client.PutAsJsonAsync("messages", message);
        }
    }
}
