using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.FeatureServiceDtos;
using Multishop.WebUI.Services.CatalogServices.FeatureServiceServices;
using Multishop.WebUI.Settings;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeService(IFeatureServiceService _featureServiceService): ViewComponent
    {
      
        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            var values = await _featureServiceService.GetAllFeatureServicesAsync();
            return View(values);
        }
    }
}
