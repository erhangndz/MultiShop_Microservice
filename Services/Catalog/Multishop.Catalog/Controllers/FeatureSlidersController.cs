using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.FeatureSliderDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Services.FeatureSliderServices;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController(IFeatureSliderService _featureSliderService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _featureSliderService.GetAllAsync();
            return Ok(_mapper.Map<List<ResultFeatureSliderDto>>(values));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var newValue = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _featureSliderService.CreateAsync(newValue);
            return Ok(newValue);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _featureSliderService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _featureSliderService.UpdateAsync(value);
            return Ok("Öne Çıkan Alan Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _featureSliderService.DeleteAsync(id);
            return Ok("Öne Çıkan Alan Silindi");
        }

        [HttpGet("ShowOnHome/{id}")]
        public async Task<IActionResult> ShowOnHome(string id)
        {
            await _featureSliderService.ShowOnHomeAsync(id);
            return Ok();
        }

        [HttpGet("DontShowOnHome/{id}")]
        public async Task<IActionResult> DontShowOnHome(string id)
        {
            await _featureSliderService.DontShowOnHomeAsync(id);
            return Ok();
        }

    }
}
