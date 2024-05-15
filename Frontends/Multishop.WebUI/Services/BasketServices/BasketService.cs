using Multishop.WebDTO.DTOs.BasketDtos;
using Multishop.WebUI.Services.Interfaces;

namespace Multishop.WebUI.Services.BasketServices
{
    public class BasketService(HttpClient _client) : IBasketService
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
                   var existItem= values.BasketItems.FirstOrDefault(x => x.ProductId == basketItemDto.ProductId);
                    existItem.Quantity += 1;
                    
                }
            }

            await SaveBasketAsync(values);

        }

        public async Task DeleteBasketAsync()
        {
            
            await _client.DeleteAsync("baskets");
        }

        public async Task<BasketTotalDto> GetBasketAsync()
        {
       
            return await _client.GetFromJsonAsync<BasketTotalDto>("baskets");
        }

        public async Task<bool> RemoveBasketItemAsync(string productId)
        {
            var values = await GetBasketAsync();
            var deletedItem = values.BasketItems.FirstOrDefault(x=>x.ProductId==productId);
            if (deletedItem.Quantity > 1)
            {
                deletedItem.Quantity -= 1;
                await SaveBasketAsync(values);
            }
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
