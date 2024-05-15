using Multishop.WebDTO.DTOs.CatalogDtos.BrandDtos;

namespace Multishop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService(HttpClient _client) : IBrandService
    {
        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            await _client.PostAsJsonAsync("brands", createBrandDto);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _client.DeleteAsync("brands/" + id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandsAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultBrandDto>>("brands");
        }

        public async Task<UpdateBrandDto> GetBrandByIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<UpdateBrandDto>("brands/" + id);
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _client.PutAsJsonAsync("brands", updateBrandDto);
        }
    }
}
