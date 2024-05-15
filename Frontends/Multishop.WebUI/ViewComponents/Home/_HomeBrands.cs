using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.BrandDtos;
using Multishop.WebUI.Services.CatalogServices.BrandServices;
using Multishop.WebUI.Services.Interfaces;
using Multishop.WebUI.Settings;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeBrands(IBrandService _brandService):ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var values = await _brandService.GetAllBrandsAsync();
            return View(values);
        }
    }
}
