using Multishop.WebDTO.DTOs.CatalogDtos.AboutDtos;

namespace Multishop.WebUI.Services.CatalogServices.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDto>> GetAllAboutsAsync();

        Task CreateAboutAsync(CreateAboutDto createAboutDto);
        Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);

        Task DeleteAboutAsync(string id);

        Task<UpdateAboutDto> GetAboutByIdAsync(string id);

    }
}
