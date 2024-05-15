using Multishop.WebDTO.DTOs.CatalogDtos.SpecialOfferDtos;

namespace Multishop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService(HttpClient _client) : ISpecialOfferService
    {
        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _client.PostAsJsonAsync("specialOffers", createSpecialOfferDto);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _client.DeleteAsync("specialOffers/" + id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultSpecialOfferDto>>("specialOffers");
        }

        public async Task<UpdateSpecialOfferDto> GetSpecialOfferByIdAsync(string id)
        {
            return await _client.GetFromJsonAsync<UpdateSpecialOfferDto>("specialOffers/" + id);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _client.PutAsJsonAsync("specialOffers", updateSpecialOfferDto);
        }
    }
}
