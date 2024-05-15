using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductPhotoDtos;
using Multishop.WebUI.Services.CatalogServices.ProductPhotoServices;
using Multishop.WebUI.Settings;

namespace Multishop.WebUI.ViewComponents.ProductDetails
{
    public class _ProductDetailCarousel(IProductPhotoService _productPhotoService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productPhotoService.GetPhotosByProductIdAsync(id);
            return View(values);
        }
    }
}
