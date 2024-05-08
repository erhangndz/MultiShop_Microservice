using Multishop.WebDTO.DTOs.CatalogDtos.CategoryDtos;

namespace Multishop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService(HttpClient _client) : ICategoryService
    {
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            await _client.PostAsJsonAsync("categories", createCategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _client.DeleteAsync("categories/" + id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
        }

        public async Task<UpdateCategoryDto> GetCategoryByIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<UpdateCategoryDto>("categories/" + id);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            await _client.PutAsJsonAsync("categories", updateCategoryDto);
        }
    }
}
