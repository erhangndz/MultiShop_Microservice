using Multishop.WebDTO.DTOs.CatalogDtos.FeatureSliderDtos;

namespace Multishop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync();

        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);

        Task DeleteFeatureSliderAsync(string id);

        Task<UpdateFeatureSliderDto> GetFeatureSliderByIdAsync(string id);

        Task ShowOnHomeAsync(string id);
        Task DontShowOnHomeAsync(string id);
    }
}
