using Multishop.WebDTO.DTOs.CatalogDtos.FeatureServiceDtos;

namespace Multishop.WebUI.Services.CatalogServices.FeatureServiceServices
{
    public interface IFeatureServiceService
    {
        Task<List<ResultFeatureServiceDto>> GetAllFeatureServicesAsync();

        Task CreateFeatureServiceAsync(CreateFeatureServiceDto createFeatureServiceDto);
        Task UpdateFeatureServiceAsync(UpdateFeatureServiceDto updateFeatureServiceDto);

        Task DeleteFeatureServiceAsync(string id);

        Task<UpdateFeatureServiceDto> GetFeatureServiceByIdAsync(string id);

    }
}
