using AutoMapper;
using MongoDB.Driver;
using Multishop.Catalog.Dtos.ProductPhotoDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.ProductPhotoServices
{
    public class ProductPhotoService : GenericRepository<ProductPhoto>, IProductPhotoService
    {
        private readonly IMongoCollection<ProductPhoto> _productCollection;
        private readonly IMapper _mapper;
        public ProductPhotoService(IDatabaseSettings settings,IMapper mapper) : base(settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _productCollection = database.GetCollection<ProductPhoto>(typeof(ProductPhoto).Name.ToLowerInvariant());
            _mapper = mapper;
        }

        public async Task<List<ResultProductPhotoDto>> GetPhotosByProductId(string id)
        {
            var values = await _productCollection.Find(x => x.ProductId == id).ToListAsync();
            return _mapper.Map<List<ResultProductPhotoDto>>(values);
        }
    }
}
