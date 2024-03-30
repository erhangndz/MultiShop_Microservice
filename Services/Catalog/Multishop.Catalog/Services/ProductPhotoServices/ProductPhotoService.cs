using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.ProductPhotoServices
{
    public class ProductPhotoService : GenericRepository<ProductPhoto>, IProductPhotoService
    {
        public ProductPhotoService(IDatabaseSettings settings) : base(settings)
        {
        }
    }
}
