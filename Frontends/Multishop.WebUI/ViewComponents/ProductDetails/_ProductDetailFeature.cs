using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductDtos;
using Multishop.WebUI.Services.CatalogServices.ProductServices;
using Multishop.WebUI.Settings;

namespace Multishop.WebUI.ViewComponents.ProductDetails
{
    public class _ProductDetailFeature(IProductService _productService): ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.GetProductByIdAsync(id);
            return View(values);
           
        }
    }
}
