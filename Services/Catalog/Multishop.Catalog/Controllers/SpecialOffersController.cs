using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.SpecialOfferDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Services;
using Multishop.Catalog.Services.SpecialOfferServices;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController(ISpecialOfferService _SpecialOfferService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _SpecialOfferService.GetAllAsync();
            return Ok(_mapper.Map<List<ResultSpecialOfferDto>>(values));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var newValue = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
            await _SpecialOfferService.CreateAsync(newValue);
            return Ok(newValue);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _SpecialOfferService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var value = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
            await _SpecialOfferService.UpdateAsync(value);
            return Ok("Özel Teklif Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _SpecialOfferService.DeleteAsync(id);
            return Ok("Özel Teklif Silindi");
        }


    }
}
