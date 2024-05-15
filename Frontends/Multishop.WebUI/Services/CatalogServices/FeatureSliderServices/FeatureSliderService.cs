using Multishop.WebDTO.DTOs.CatalogDtos.FeatureSliderDtos;

namespace Multishop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService(HttpClient _client) : IFeatureSliderService
    {
        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _client.PostAsJsonAsync("featureSliders", createFeatureSliderDto);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _client.DeleteAsync("featureSliders/" + id);
        }

        public async Task DontShowOnHomeAsync(string id)
        {
            await _client.GetAsync("featureSliders/DontShowOnHome/" + id);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultFeatureSliderDto>>("featureSliders");
        }

        public async Task<UpdateFeatureSliderDto> GetFeatureSliderByIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<UpdateFeatureSliderDto>("featureSliders/" + id);
        }

        public async Task ShowOnHomeAsync(string id)
        {
            await _client.GetAsync("featureSliders/ShowOnHome/" + id);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _client.PutAsJsonAsync("featureSliders", updateFeatureSliderDto);
        }
    }
}
