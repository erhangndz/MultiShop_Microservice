using AutoMapper;
using MongoDB.Driver;
using Multishop.Catalog.Dtos.ProductDetailDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : GenericRepository<ProductDetail>, IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _collection;
        private readonly IMapper _mapper;
        public ProductDetailService(IDatabaseSettings settings, IMapper mapper) : base(settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<ProductDetail>(typeof(ProductDetail).Name.ToLowerInvariant());
            _mapper = mapper;
        }

        public async Task<ResultProductDetailDto> GetDetailsByProductIdAsync(string id)
        {
            var values = await _collection.Find(x => x.ProductId == id).ToListAsync();
            return _mapper.Map<ResultProductDetailDto>(values);

        }
    }
}
