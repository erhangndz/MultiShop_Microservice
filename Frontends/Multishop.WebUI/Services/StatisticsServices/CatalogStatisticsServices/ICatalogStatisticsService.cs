namespace Multishop.WebUI.Services.StatisticsServices.CatalogStatisticsServices
{
    public interface ICatalogStatisticsService
    {
        Task<long> GetCategoryCountAsync();
        Task<long> GetProductCountAsync();
        Task<long> GetBrandCountAsync();
        Task<decimal> GetAvgProductPriceAsync();
        Task<string> GetMostExpensiveProductName();
        Task<string> GetCheapestProductName();
    }
}
