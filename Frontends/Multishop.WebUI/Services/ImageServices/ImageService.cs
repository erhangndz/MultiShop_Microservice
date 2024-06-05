using Multishop.WebDTO.DTOs.ImageDtos;
using System.Reflection;

namespace Multishop.WebUI.Services.ImageServices
{
    public class ImageService(HttpClient _client) : IImageService
    {

       
        public async Task CreateImageAsync(CreateImageDto image)
        {
          
          
            var formContent = new MultipartFormDataContent();
            formContent.Add(new StringContent(image.Title), "Title");
            formContent.Add(new StreamContent(image.Photo.OpenReadStream()), "Photo", Path.GetFileName(image.Photo.FileName));
            await  _client.PostAsync("imageUploads", formContent);

           
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
