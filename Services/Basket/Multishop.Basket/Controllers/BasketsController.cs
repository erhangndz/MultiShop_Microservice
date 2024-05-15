using Microsoft.AspNetCore.Mvc;
using Multishop.Basket.Dtos;
using Multishop.Basket.LoginServices;
using Multishop.Basket.Services;

namespace Multishop.Basket.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController(IBasketService basketService, ILoginService loginService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBasketDetail(string id)
        {
            id = loginService.GetUserId;
            var values = await basketService.GetBasketAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = loginService.GetUserId;
            await basketService.SaveBasketAsync(basketTotalDto);
            return Ok("Sepetteki Değişiklikler Kaydedildi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasket(string id)
        {
        id=loginService.GetUserId;
            await basketService.DeleteBasketAsync(id);
            return Ok("Sepet Silindi");
        }

    }
}

