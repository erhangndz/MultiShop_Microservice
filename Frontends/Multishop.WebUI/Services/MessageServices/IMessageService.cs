using Multishop.WebDTO.DTOs.MessageDtos;

namespace Multishop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {

        Task<List<ResultMessageDto>> GetAllMessagesAsync();
        Task<List<ResultMessageDto>> GetInboxMessagesAsync(string id);
        Task<List<ResultMessageDto>> GetSentBoxMessagesAsync(string id);
        Task<UpdateMessageDto> GetMessageByIdAsync(int id);
        Task UpdateMessageAsync(UpdateMessageDto message);
        Task CreateMessageAsync(CreateMessageDto message);
        Task DeleteMessageAsync(int id);

        Task<int> GetMessageCountByReceiverIdAsync(string id);
    }
}
