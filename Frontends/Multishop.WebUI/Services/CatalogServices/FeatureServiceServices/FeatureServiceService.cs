using Multishop.WebDTO.DTOs.CatalogDtos.FeatureServiceDtos;

namespace Multishop.WebUI.Services.CatalogServices.FeatureServiceServices
{
    public class FeatureServiceService(HttpClient _client) : IFeatureServiceService
    {
        public async Task CreateFeatureServiceAsync(CreateFeatureServiceDto createFeatureServiceDto)
        {
            await _client.PostAsJsonAsync("featureServices", createFeatureServiceDto);
        }

        public async Task DeleteFeatureServiceAsync(string id)
        {
            await _client.DeleteAsync("featureServices/" + id);
        }

        public async Task<List<ResultFeatureServiceDto>> GetAllFeatureServicesAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultFeatureServiceDto>>("featureServices");
        }

        public async Task<UpdateFeatureServiceDto> GetFeatureServiceByIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<UpdateFeatureServiceDto>("featureServices/" + id);
        }

        public async Task UpdateFeatureServiceAsync(UpdateFeatureServiceDto updateFeatureServiceDto)
        {
            await _client.PutAsJsonAsync("featureServices", updateFeatureServiceDto);
        }
    }
}
