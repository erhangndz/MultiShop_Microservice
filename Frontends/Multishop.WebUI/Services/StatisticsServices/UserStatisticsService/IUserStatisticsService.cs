namespace Multishop.WebUI.Services.StatisticsServices.UserStatisticsService
{
    public interface IUserStatisticsService
    {
        Task<int> GetUserCountAsync();

    }
}
