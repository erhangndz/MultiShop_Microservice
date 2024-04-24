using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.FeatureServiceDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Services.FeatureServicesServices;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureServicesController(IFeatureServiceService _featureServiceService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _featureServiceService.GetAllAsync();
            return Ok(_mapper.Map<List<ResultFeatureServiceDto>>(values));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureServiceDto createFeatureServiceDto)
        {
            var newValue = _mapper.Map<FeatureService>(createFeatureServiceDto);
            await _featureServiceService.CreateAsync(newValue);
            return Ok(newValue);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _featureServiceService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeatureServiceDto updateFeatureServiceDto)
        {
            var value = _mapper.Map<FeatureService>(updateFeatureServiceDto);
            await _featureServiceService.UpdateAsync(value);
            return Ok("Hizmet Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _featureServiceService.DeleteAsync(id);
            return Ok("Hizmet Silindi");
        }
    }
}
