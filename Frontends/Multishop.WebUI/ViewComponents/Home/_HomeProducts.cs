using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductDtos;
using Multishop.WebUI.Services.CatalogServices.ProductServices;
using Multishop.WebUI.Settings;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeProducts(IProductService _productService):ViewComponent
    {
       
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var values = await _productService.GetAllProductsAsync();
            return View(values);
        }
    }
}
