namespace Multishop.Catalog.Services.StatisticsServices
{
    public interface IStatisticsService
    {
        Task<long> GetCategoryCountAsync();
        Task<long> GetProductCountAsync();
        Task<long> GetBrandCountAsync();
        Task<decimal> GetAvgProductPriceAsync();
        Task<string> GetMostExpensiveProductName();
        Task<string> GetCheapestProductName();
    }
}
