using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.ProductServices
{
    public class ProductService : GenericRepository<Product>, IProductService
    {
        public ProductService(DatabaseSettings settings) : base(settings)
        {
        }
    }
}
