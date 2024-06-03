using Multishop.WebDTO.DTOs.ImageDtos;

namespace Multishop.WebUI.Services.ImageServices
{
    public interface IImageService
    {
        Task CreateImageAsync(CreateImageDto image);
        Task UpdateImageAsync(UpdateImageDto image);

        Task<UpdateImageDto> GetImageByIdAsync(int id);
        Task<List<ResultImageDto>> GetAllImagesAsync();

        Task DeleteImageAsync(int id);
    }
}
