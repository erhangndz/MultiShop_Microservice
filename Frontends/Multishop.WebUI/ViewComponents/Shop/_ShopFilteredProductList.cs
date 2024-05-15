using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductDtos;
using Multishop.WebUI.Services.CatalogServices.ProductServices;

namespace Multishop.WebUI.ViewComponents.Shop
{
    public class _ShopFilteredProductList(IProductService _productService) : ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            id = ViewBag.id;

            if (id == null)
            {
                var values = await _productService.GetAllProductsAsync();
                return View(values);
            }
            else
            {
                var values = await _productService.GetProductsByCategoryIdAsync(id);
                return View(values);
            }


        }
    }
}
