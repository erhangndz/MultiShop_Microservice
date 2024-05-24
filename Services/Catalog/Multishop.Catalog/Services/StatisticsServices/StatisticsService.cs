
using Multishop.Catalog.Entities;

namespace Multishop.Catalog.Services.StatisticsServices
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Brand> _brandRepository;

        public StatisticsService(IRepository<Category> categoryRepository, IRepository<Product> productRepository, IRepository<Brand> brandRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _brandRepository = brandRepository;
        }

        public async Task<decimal> GetAvgProductPriceAsync()
        {
           return await _productRepository.GetAvgValueAsync();
        }

        public async Task<long> GetBrandCountAsync()
        {
            return await _brandRepository.GetCountAsync();
        }

        public async Task<long> GetCategoryCountAsync()
        {
            return await _categoryRepository.GetCountAsync();
        }

        public async Task<long> GetProductCountAsync()
        {
            return await _productRepository.GetCountAsync();
        }
    }
}
