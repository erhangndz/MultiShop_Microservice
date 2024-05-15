using Multishop.WebDTO.DTOs.CatalogDtos.OfferDiscountDtos;

namespace Multishop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public interface IOfferDiscountService
    {

        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountsAsync();

        Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);

        Task DeleteOfferDiscountAsync(string id);

        Task<UpdateOfferDiscountDto> GetOfferDiscountByIdAsync(string id);
    }
}
