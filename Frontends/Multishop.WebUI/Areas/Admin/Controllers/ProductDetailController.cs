using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductDetailDtos;
using Multishop.WebUI.Services.CatalogServices.ProductDetailServices;
using Multishop.WebUI.Services.CatalogServices.ProductServices;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProductDetailController(IProductDetailService _productDetailService,IProductService _productService) : Controller
    {
        
       public async Task<IActionResult> Details(string id)
        {
            var values = await _productDetailService.GetDetails(id);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateDetail()
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
        public async Task<IActionResult> CreateDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public  async Task<IActionResult> UpdateDetail(string id)
        {
            var values = await _productDetailService.GetProductDetailByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return RedirectToAction("Index", "Product");
        }
    }
}
