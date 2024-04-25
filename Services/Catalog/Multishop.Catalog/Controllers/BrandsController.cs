using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.BrandDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Services.BrandServices;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController(IBrandService _BrandService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _BrandService.GetAllAsync();
            return Ok(_mapper.Map<List<ResultBrandDto>>(values));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandDto createBrandDto)
        {
            var newValue = _mapper.Map<Brand>(createBrandDto);
            await _BrandService.CreateAsync(newValue);
            return Ok(newValue);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _BrandService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBrandDto updateBrandDto)
        {
            var value = _mapper.Map<Brand>(updateBrandDto);
            await _BrandService.UpdateAsync(value);
            return Ok("Marka Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _BrandService.DeleteAsync(id);
            return Ok("Marka Silindi");
        }
    }
}
