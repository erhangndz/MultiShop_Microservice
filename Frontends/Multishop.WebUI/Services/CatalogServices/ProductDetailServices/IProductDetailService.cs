using Multishop.WebDTO.DTOs.CatalogDtos.ProductDetailDtos;

namespace Multishop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();

        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);

        Task DeleteProductDetailAsync(string id);

        Task<UpdateProductDetailDto> GetProductDetailByIdAsync(string id);

        Task<List<ResultProductDetailDto>> GetDetails(string id);
    }
}
