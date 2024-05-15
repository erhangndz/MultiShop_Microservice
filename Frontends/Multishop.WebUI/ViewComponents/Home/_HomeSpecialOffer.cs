using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.SpecialOfferDtos;
using Multishop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Multishop.WebUI.Settings;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeSpecialOffer(ISpecialOfferService _specialOfferService):ViewComponent
    {
      
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var values = await _specialOfferService.GetAllSpecialOffersAsync();
            return View(values);
        }
    }
}
