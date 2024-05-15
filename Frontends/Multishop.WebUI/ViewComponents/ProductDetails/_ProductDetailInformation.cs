using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductDetailDtos;
using Multishop.WebUI.Services.CatalogServices.ProductDetailServices;
using Multishop.WebUI.Settings;

namespace Multishop.WebUI.ViewComponents.ProductDetails
{
    public class _ProductDetailInformation(IProductDetailService _productDetailService):ViewComponent
    {
       
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productDetailService.GetDetails(id);
            return View(values);
        }
       
    }
}
