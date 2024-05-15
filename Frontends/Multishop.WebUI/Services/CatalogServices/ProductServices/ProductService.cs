using Multishop.WebDTO.DTOs.CatalogDtos.ProductDtos;

namespace Multishop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService(HttpClient _client) : IProductService
    {
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _client.PostAsJsonAsync("products", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _client.DeleteAsync("products/" + id);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultProductDto>>("products");
        }

        public async Task<UpdateProductDto> GetProductByIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<UpdateProductDto>("products/" + id);
        }

        public async Task<List<ResultProductDto>> GetProductsByCategoryIdAsync(string id)
        {
           return await _client.GetFromJsonAsync<List<ResultProductDto>>("products/getProductsByCategoryId/" + id);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _client.PutAsJsonAsync("products", updateProductDto);
        }
    }
}
