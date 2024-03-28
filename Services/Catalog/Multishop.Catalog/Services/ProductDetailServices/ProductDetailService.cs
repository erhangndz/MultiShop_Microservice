using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : GenericRepository<ProductDetail>, IProductDetailService
    {
        public ProductDetailService(DatabaseSettings settings) : base(settings)
        {
        }
    }
}
