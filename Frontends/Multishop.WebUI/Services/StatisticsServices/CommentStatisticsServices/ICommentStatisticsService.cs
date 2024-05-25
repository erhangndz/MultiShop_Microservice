namespace Multishop.WebUI.Services.StatisticsServices.CommentStatisticsServices
{
    public interface ICommentStatisticsService
    {

        Task<int> GetActiveCommentCountAsync();
        Task<int> GetPassiveCommentCountAsync();
        Task<int> GetTotalCommentCountAsync();
    }
}
