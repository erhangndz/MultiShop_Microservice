namespace Multishop.SignalRRealTimeApi.Services
{
    public interface ISignalRService
    {
        Task<int> GetMessageCountByReceiverIdAsync(string id);

        Task<int> GetPassiveCommentCountAsync();
    }
}
