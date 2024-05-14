using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductDtos;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductPhotoDtos;
using Multishop.WebUI.Services.CatalogServices.ProductPhotoServices;
using Multishop.WebUI.Services.CatalogServices.ProductServices;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProductPhotoController(IProductPhotoService _productPhotoService, IProductService _productService) : Controller
    {
      
        public async Task<IActionResult> Index()
        {
            var values = await _productPhotoService.GetAllProductPhotosAsync();
            return View(values);
        }

        public async Task<IActionResult> GetPhotosByProductId(string id)
        {
            var values =await _productPhotoService.GetPhotosByProductIdAsync(id);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProductPhoto()
        {
            var productList = await _productService.GetAllProductsAsync();
            ViewBag.products = (from x in productList
                                select new SelectListItem
                                {
                                    Text = x.ProductName,
                                    Value = x.Id
                                }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductPhoto(CreateProductPhotoDto createProductPhotoDto)
        {
            await _productPhotoService.CreateProductPhotoAsync(createProductPhotoDto);
            return RedirectToAction("Index","Product");
        }

        public async Task<IActionResult> DeleteProductPhoto(string id)
        {
            await _productPhotoService.DeleteProductPhotoAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProductPhoto(string id)
        {
            var values = await _productPhotoService.GetProductPhotoByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductPhoto(UpdateProductPhotoDto updateProductPhotoDto)
        {
            await _productPhotoService.UpdateProductPhotoAsync(updateProductPhotoDto);
            return RedirectToAction("Index","Product");
        }
    }
}
