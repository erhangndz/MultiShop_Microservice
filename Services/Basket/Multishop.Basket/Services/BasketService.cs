
using Multishop.Basket.Dtos;
using Multishop.Basket.Settings;
using Newtonsoft.Json;

namespace Multishop.Basket.Services
{
    public class BasketService(RedisService _redisService) : IBasketService
    {
        public async Task DeleteBasketAsync(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasketAsync(string userId)
        {
          var existBasket = await _redisService.GetDb().StringGetAsync(userId);
            if (string.IsNullOrEmpty(existBasket))
            {
                return new BasketTotalDto();
            }
            return JsonConvert.DeserializeObject<BasketTotalDto>(existBasket);

        }

        public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonConvert.SerializeObject(basketTotalDto));
        }
    }
}
