using Multishop.WebDTO.DTOs.CatalogDtos.SpecialOfferDtos;

namespace Multishop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOffersAsync();

        Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);

        Task DeleteSpecialOfferAsync(string id);

        Task<UpdateSpecialOfferDto> GetSpecialOfferByIdAsync(string id);
    }
}
