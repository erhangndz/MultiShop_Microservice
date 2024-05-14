using Multishop.WebDTO.DTOs.CatalogDtos.ProductPhotoDtos;

namespace Multishop.WebUI.Services.CatalogServices.ProductPhotoServices
{
    public class ProductPhotoService(HttpClient _client) : IProductPhotoService
    {
        public async Task CreateProductPhotoAsync(CreateProductPhotoDto createProductPhotoDto)
        {
            await _client.PostAsJsonAsync("productPhotos", createProductPhotoDto);
        }

        public async Task DeleteProductPhotoAsync(string id)
        {
            await _client.DeleteAsync("productPhotos/" + id);
        }

        public async Task<List<ResultProductPhotoDto>> GetAllProductPhotosAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultProductPhotoDto>>("productPhotos");
        }

        public async Task<List<ResultProductPhotoDto>> GetPhotosByProductIdAsync(string id)
        {
           return await _client.GetFromJsonAsync<List<ResultProductPhotoDto>>("productphotos/getPhotosByProductId/" + id);
        }

        public async Task<UpdateProductPhotoDto> GetProductPhotoByIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<UpdateProductPhotoDto>("productPhotos/" + id);
        }

        public async Task UpdateProductPhotoAsync(UpdateProductPhotoDto updateProductPhotoDto)
        {
            await _client.PutAsJsonAsync("productPhotos", updateProductPhotoDto);
        }
    }
}
