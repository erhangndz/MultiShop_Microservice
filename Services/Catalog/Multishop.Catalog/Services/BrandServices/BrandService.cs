using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.BrandServices
{
    public class BrandService : GenericRepository<Brand>, IBrandService
    {
        public BrandService(IDatabaseSettings settings) : base(settings)
        {
        }
    }
}
