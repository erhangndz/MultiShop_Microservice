
using MongoDB.Driver;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Services.ProductServices;

namespace Multishop.Catalog.Services.StatisticsServices
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IProductService _productService;
        private readonly IRepository<Brand> _brandRepository;

        public StatisticsService(IRepository<Category> categoryRepository, IRepository<Brand> brandRepository, IProductService productService)
        {
            _categoryRepository = categoryRepository;

            _brandRepository = brandRepository;
            _productService = productService;
        }

        public async Task<decimal> GetAvgProductPriceAsync()
        {
           return await _productService.GetAvgPriceAsync();
        }

        public async Task<long> GetBrandCountAsync()
        {
            return await _brandRepository.GetCountAsync();
        }

        public async Task<long> GetCategoryCountAsync()
        {
            return await _categoryRepository.GetCountAsync();
        }

        public async Task<string> GetCheapestProductName()
        {
           return await _productService.GetCheapestProductName();
        }

        public async Task<string> GetMostExpensiveProductName()
        {
          return await _productService.GetMostExpensiveProductName();
        }

        public async Task<long> GetProductCountAsync()
        {
            return await _productService.GetCountAsync();
        }
    }
}
