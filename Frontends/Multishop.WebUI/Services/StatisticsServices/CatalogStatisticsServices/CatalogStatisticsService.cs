
namespace Multishop.WebUI.Services.StatisticsServices.CatalogStatisticsServices
{
    public class CatalogStatisticsService(HttpClient _client) : ICatalogStatisticsService
    {
        public async Task<decimal> GetAvgProductPriceAsync()
        {
            return await _client.GetFromJsonAsync<decimal>("statistics/GetAvgProductPrice");
        }

        public async Task<long> GetBrandCountAsync()
        {
            return await _client.GetFromJsonAsync<long>("statistics/GetBrandCount");
        }

        public async Task<long> GetCategoryCountAsync()
        {
            return await _client.GetFromJsonAsync<long>("statistics/GetCategoryCount");
        }

        public async Task<string> GetCheapestProductName()
        {
            return await _client.GetStringAsync("statistics/GetCheapestProductName");
        }

        public async Task<string> GetMostExpensiveProductName()
        {
            return await _client.GetStringAsync("statistics/GetMostExpensiveProductName");
        }

        public async Task<long> GetProductCountAsync()
        {
            return await _client.GetFromJsonAsync<long>("statistics/GetProductCount");
        }
    }
}
