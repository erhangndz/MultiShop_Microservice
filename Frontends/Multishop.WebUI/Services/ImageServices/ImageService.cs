using Multishop.WebDTO.DTOs.ImageDtos;

namespace Multishop.WebUI.Services.ImageServices
{
    public class ImageService(HttpClient _client) : IImageService
    {
        public async Task CreateImageAsync(CreateImageDto image)
        {
            await _client.PostAsJsonAsync("imageUploads", image);
        }

        public async Task DeleteImageAsync(int id)
        {
            await _client.DeleteAsync("imageUploads/" + id);
        }

        public async Task<List<ResultImageDto>> GetAllImagesAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultImageDto>>("imageUploads");
        }

        public async Task<UpdateImageDto> GetImageByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateImageDto>("imageUploads/" + id);
        }

        public async Task UpdateImageAsync(UpdateImageDto image)
        {
            await _client.PutAsJsonAsync("imageUploads", image);
        }
    }
}
