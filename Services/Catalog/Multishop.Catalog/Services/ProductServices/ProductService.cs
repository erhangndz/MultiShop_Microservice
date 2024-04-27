using AutoMapper;
using MongoDB.Driver;
using Multishop.Catalog.Dtos.ProductDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.ProductServices
{
    public class ProductService : GenericRepository<Product>, IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        public ProductService(IDatabaseSettings settings,IMapper mapper) : base(settings) 
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _productCollection = database.GetCollection<Product>(typeof(Product).Name.ToLowerInvariant());
            _mapper= mapper;
        }

        public async Task<List<ResultProductDto>> GetProductsByCategoryIdAsync(string categoryId)
        {
          var values = await _productCollection.Find(x=>x.CategoryId == categoryId).ToListAsync();

            return _mapper.Map<List<ResultProductDto>>(values);
        }
    }
}
