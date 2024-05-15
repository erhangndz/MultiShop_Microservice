using Multishop.WebDTO.DTOs.BasketDtos;
using Multishop.WebUI.Services.Interfaces;

namespace Multishop.WebUI.Services.BasketServices
{
    public class BasketService(HttpClient _client,ILoginService _loginService) : IBasketService
    {
        public async Task AddBasketItemAsync(BasketItemDto basketItemDto)
        {
           var values = await GetBasketAsync();
            if(values != null)
            {
                if (!values.BasketItems.Any(x=>x.ProductId==basketItemDto.ProductId))
                {
                    values.BasketItems.Add(basketItemDto);
                }

                else
                {
                    values=new BasketTotalDto();
                    values.BasketItems.Add(basketItemDto);
                }
            }

            await SaveBasketAsync(values);

        }

        public async Task DeleteBasketAsync()
        {
            
            await _client.DeleteAsync("baskets/" + _loginService.GetUserId);
        }

        public async Task<BasketTotalDto> GetBasketAsync()
        {
       
            return await _client.GetFromJsonAsync<BasketTotalDto>("baskets/" + _loginService.GetUserId);
        }

        public async Task<bool> RemoveBasketItemAsync(string productId)
        {
            var values = await GetBasketAsync();
            var deletedItem = values.BasketItems.FirstOrDefault(x=>x.ProductId==productId);
            var result = values.BasketItems.Remove(deletedItem);
             await SaveBasketAsync(values);
            return true;

        }

        public async Task SaveBasketAsync(BasketTotalDto basketTotalDto)
        {
            await _client.PostAsJsonAsync("baskets", basketTotalDto);
        }
    }
}
