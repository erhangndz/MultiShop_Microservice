using Multishop.Catalog.Dtos.ProductDtos;
using Multishop.Catalog.Entities;

namespace Multishop.Catalog.Services.ProductServices
{
    public interface IProductService : IRepository<Product>
    {

        Task<List<ResultProductDto>> GetProductsByCategoryIdAsync(string categoryId);

        Task<decimal> GetAvgPriceAsync();

        Task<string> GetMostExpensiveProductName();
        Task<string> GetCheapestProductName();
    }
}
