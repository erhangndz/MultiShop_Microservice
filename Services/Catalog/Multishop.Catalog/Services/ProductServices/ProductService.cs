using AutoMapper;
using MongoDB.Bson;
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
        public ProductService(IDatabaseSettings settings, IMapper mapper) : base(settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _productCollection = database.GetCollection<Product>(typeof(Product).Name.ToLowerInvariant());
            _mapper = mapper;
        }

        public async Task<List<ResultProductDto>> GetProductsByCategoryIdAsync(string categoryId)
        {
            var values = await _productCollection.Find(x => x.CategoryId == categoryId).ToListAsync();

            return _mapper.Map<List<ResultProductDto>>(values);
        }


        public async Task<decimal> GetAvgPriceAsync()
        {
            var pipeline = new BsonDocument[]
            {
                new BsonDocument("$group",new BsonDocument
                {
                    {"_id",null },
                    {"averagePrice",new BsonDocument("$avg","$price") }
                })


            };

            var result = await _productCollection.AggregateAsync<BsonDocument>(pipeline);
            var values = result.FirstOrDefault().GetValue("averagePrice", decimal.Zero).AsDecimal;
            return values;
        }

        public async Task<string> GetMostExpensiveProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x => x.Price);
            var projection = Builders<Product>.Projection.Include(y =>
                                                                  y.ProductName).Exclude("Id");

            var product = await _productCollection.Find(filter)
                                                  .Sort(sort)
                                                  .Project(projection)
                                                  .FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }

        public async Task<string> GetCheapestProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x => x.Price);
            var projection = Builders<Product>.Projection.Include(y =>
                                                                  y.ProductName).Exclude("Id");

            var product = await _productCollection.Find(filter)
                                                  .Sort(sort)
                                                  .Project(projection)
                                                  .FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }
    }
}
