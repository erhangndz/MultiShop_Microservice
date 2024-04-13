

using Multishop.Basket.Dtos;

namespace Multishop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketAsync(string userId);
        Task SaveBasketAsync(BasketTotalDto basketTotalDto);
        Task DeleteBasketAsync(string userId);
    }
}
