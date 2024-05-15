using Multishop.WebDTO.DTOs.CatalogDtos.OfferDiscountDtos;

namespace Multishop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public class OfferDiscountService(HttpClient _client) : IOfferDiscountService
    {
        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _client.PostAsJsonAsync("offerDiscounts", createOfferDiscountDto);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
           await _client.DeleteAsync("offerDiscounts/" + id);
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountsAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultOfferDiscountDto>>("offerDiscounts");
        }

        public async Task<UpdateOfferDiscountDto> GetOfferDiscountByIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<UpdateOfferDiscountDto>("offerDiscounts/" + id);
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _client.PutAsJsonAsync("offerDiscounts", updateOfferDiscountDto);
        }
    }
}
