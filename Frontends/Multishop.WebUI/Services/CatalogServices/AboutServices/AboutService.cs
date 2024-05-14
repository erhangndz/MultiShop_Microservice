using Multishop.WebDTO.DTOs.CatalogDtos.AboutDtos;

namespace Multishop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService(HttpClient _client) : IAboutService
    {
        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _client.PostAsJsonAsync("abouts", createAboutDto);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _client.DeleteAsync("abouts/" + id);
        }

        public async Task<UpdateAboutDto> GetAboutByIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<UpdateAboutDto>("abouts/" + id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutsAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _client.PutAsJsonAsync("abouts", updateAboutDto);
        }
    }
}
