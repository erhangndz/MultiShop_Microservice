using Multishop.Catalog.Entities;
using Multishop.Catalog.Settings;

namespace Multishop.Catalog.Services.CategoryServices
{
    public class CategoryService : GenericRepository<Category>, ICategoryService
    {
        public CategoryService(DatabaseSettings settings) : base(settings)
        {
        }
    }
}
