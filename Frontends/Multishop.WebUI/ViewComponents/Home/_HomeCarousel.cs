using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.FeatureSliderDtos;
using Multishop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Multishop.WebUI.Settings;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeCarousel(IFeatureSliderService _featureSliderService):ViewComponent
    {
        

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var values = await _featureSliderService.GetAllFeatureSlidersAsync();
            return View(values);
        }
    }
}
