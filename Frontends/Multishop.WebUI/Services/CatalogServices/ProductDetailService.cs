using Multishop.WebDTO.DTOs.CatalogDtos.ProductDetailDtos;

namespace Multishop.WebUI.Services.CatalogServices
{
    public class ProductDetailService(HttpClient _client) : IProductDetailService
    {
        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _client.PostAsJsonAsync("productDetails", createProductDetailDto);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _client.DeleteAsync("productDetails/" + id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultProductDetailDto>>("productDetails");
        }

        public async Task<List<ResultProductDetailDto>> GetDetails(string id)
        {
           return await _client.GetFromJsonAsync<List<ResultProductDetailDto>>("productDetails/getDetailsByProductId/" + id);
        }

        public async Task<UpdateProductDetailDto> GetProductDetailByIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<UpdateProductDetailDto>("productDetails/" + id);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _client.PutAsJsonAsync("productDetails", updateProductDetailDto);
        }
    }
}
