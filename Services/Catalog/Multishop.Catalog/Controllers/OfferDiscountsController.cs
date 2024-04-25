using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.OfferDiscountDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Services.OfferDiscountServices;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountsController(IOfferDiscountService _offerDiscountService,IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _offerDiscountService.GetAllAsync();
            return Ok(_mapper.Map<List<ResultOfferDiscountDto>>(values));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var newValue = _mapper.Map<OfferDiscount>(createOfferDiscountDto);
            await _offerDiscountService.CreateAsync(newValue);
            return Ok(newValue);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _offerDiscountService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var value = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);
            await _offerDiscountService.UpdateAsync(value);
            return Ok("İndirim teklifi Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _offerDiscountService.DeleteAsync(id);
            return Ok("İndirim teklifi Silindi");
        }
    }
}
