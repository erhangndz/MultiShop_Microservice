using Multishop.WebDTO.DTOs.CatalogDtos.BrandDtos;

namespace Multishop.WebUI.Services.CatalogServices.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandsAsync();

        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);

        Task DeleteBrandAsync(string id);

        Task<UpdateBrandDto> GetBrandByIdAsync(string id);

    }
}
