using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Multishop.Images.Context;
using Multishop.Images.Dtos;
using Multishop.Images.Entities;
using Multishop.Images.Services;
using Multishop.Images.Services.ImageServices;
using System.Security.Cryptography.Xml;

namespace Multishop.Images.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadsController(IImageService _imageService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> CreateImage(CreateImageDto image)
        {
            await _imageService.CreateImageAsync(image);
            return Ok(image);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var images = await _imageService.GetAllImagesAsync();
            return Ok(images);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(int id)
        {
            var image = await _imageService.GetImageByIdAsync(id);
            return Ok(image);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateImage(UpdateImageDto image)
        {
            await _imageService.UpdateImageAsync(image);
            return Ok(image);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _imageService.DeleteImageAsync(id);
            return Ok("Resim Silindi");
        }


    }
}
