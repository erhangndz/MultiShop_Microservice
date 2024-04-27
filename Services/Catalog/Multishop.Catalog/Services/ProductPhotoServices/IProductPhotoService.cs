using Multishop.Catalog.Dtos.ProductPhotoDtos;
using Multishop.Catalog.Entities;

namespace Multishop.Catalog.Services.ProductPhotoServices
{
    public interface IProductPhotoService : IRepository<ProductPhoto>
    {
        Task<List<ResultProductPhotoDto>> GetPhotosByProductId(string id);
    }
}
