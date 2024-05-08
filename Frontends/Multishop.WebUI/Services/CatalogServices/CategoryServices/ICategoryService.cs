using Multishop.WebDTO.DTOs.CatalogDtos.CategoryDtos;
using System.Drawing;

namespace Multishop.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService
    {

        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();

        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);

        Task DeleteCategoryAsync(string id);

        Task<UpdateCategoryDto> GetCategoryByIdAsync(string id);


    }
}
