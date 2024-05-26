namespace Multishop.WebUI.Services.StatisticsServices.MessageStatisticsServices
{
    public interface IMessageStatisticsService
    {
        Task<int> GetTotalMessageCountAsync();
    }
}
