using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.OfferDiscountDtos;
using Multishop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Multishop.WebUI.Settings;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeOfferDiscount(IOfferDiscountService _offerDiscountService):ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            var values = await _offerDiscountService.GetAllOfferDiscountsAsync();
            return View(values);
        }
    }
}
