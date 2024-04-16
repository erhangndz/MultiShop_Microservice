using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Discount.Dtos;
using Multishop.Discount.Services;

namespace Multishop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController(IDiscountService _discountService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _discountService.GetAllCouponsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _discountService.GetCouponByIdAsync(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _discountService.DeleteCouponAsync(id);
            return Ok("İndirim Kuponu Silindi");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("İndirim Kuponu Oluşturuldu");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("İndirim Kuponu Güncellendi");
        }
    }
}
