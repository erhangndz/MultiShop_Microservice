using Multishop.WebDTO.DTOs.CatalogDtos.ProductPhotoDtos;

namespace Multishop.WebUI.Services.CatalogServices.ProductPhotoServices
{
    public interface IProductPhotoService
    {
        Task<List<ResultProductPhotoDto>> GetAllProductPhotosAsync();

        Task CreateProductPhotoAsync(CreateProductPhotoDto createProductPhotoDto);
        Task UpdateProductPhotoAsync(UpdateProductPhotoDto updateProductPhotoDto);

        Task DeleteProductPhotoAsync(string id);

        Task<UpdateProductPhotoDto> GetProductPhotoByIdAsync(string id);

        Task<List<ResultProductPhotoDto>> GetPhotosByProductIdAsync(string id);
    }
}
