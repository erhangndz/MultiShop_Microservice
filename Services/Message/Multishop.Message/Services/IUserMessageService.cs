using Multishop.Message.Dtos;
using System.Globalization;

namespace Multishop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessagesAsync();
        Task<List<ResultMessageDto>> GetInboxMessagesAsync(string id);
        Task<List<ResultMessageDto>> GetSentBoxMessagesAsync(string id);
        Task<UpdateMessageDto> GetMessageByIdAsync(int id);
        Task UpdateMessageAsync(UpdateMessageDto message);
        Task CreateMessageAsync(CreateMessageDto message);
        Task DeleteMessageAsync(int id);

        Task<int> GetTotalMessageCountAsync();

        Task<int> GetMessageCountByReceiverIdAsync(string id);

    }
}
