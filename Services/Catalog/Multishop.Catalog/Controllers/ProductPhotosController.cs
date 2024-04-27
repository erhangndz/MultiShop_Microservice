using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.ProductPhotoDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Services.ProductPhotoServices;

namespace Multishop.Catalog.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPhotosController(IProductPhotoService _ProductPhotoService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _ProductPhotoService.GetAllAsync();
            return Ok(_mapper.Map<List<ResultProductPhotoDto>>(values));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductPhotoDto createProductPhotoDto)
        {
            var newValue = _mapper.Map<ProductPhoto>(createProductPhotoDto);
            await _ProductPhotoService.CreateAsync(newValue);
            return Ok(newValue);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _ProductPhotoService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductPhotoDto updateProductPhotoDto)
        {
            var value = _mapper.Map<ProductPhoto>(updateProductPhotoDto);
            await _ProductPhotoService.UpdateAsync(value);
            return Ok("Ürün Fotoğrafı Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _ProductPhotoService.DeleteAsync(id);
            return Ok("Ürün Fotoğrafı Silindi");
        }

        [HttpGet("GetPhotosByProductId/{id}")]
        public async Task<IActionResult> GetPhotosByProductId(string id)
        {
            var values = await _ProductPhotoService.GetPhotosByProductId(id);
            return Ok(values);
        }
    }
}
