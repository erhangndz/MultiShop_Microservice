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
        public async Task<IActionResult> GetBasketDetail()
        {
            
            var values = await basketService.GetBasketAsync(loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = loginService.GetUserId;
            await basketService.SaveBasketAsync(basketTotalDto);
            return Ok("Sepetteki Değişiklikler Kaydedildi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
      
            await basketService.DeleteBasketAsync(loginService.GetUserId);
            return Ok("Sepet Silindi");
        }

    }
}

