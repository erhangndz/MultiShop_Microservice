using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multishop.WebDTO.DTOs.CatalogDtos.CategoryDtos;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductDtos;
using Multishop.WebUI.Services.CatalogServices.CategoryServices;
using Multishop.WebUI.Services.CatalogServices.ProductServices;


namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProductController(IProductService _productService,ICategoryService _categoryService) : Controller
    {
       
        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetAllProductsAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categoryList = await _categoryService.GetAllCategoriesAsync();
            ViewBag.category = (from x in categoryList
                                select new SelectListItem
                                {
                                    Text = x.CategoryName,
                                    Value = x.CategoryName
                                }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            

            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var categoryList = await _categoryService.GetAllCategoriesAsync();
            ViewBag.category = (from x in categoryList
                                select new SelectListItem
                                {
                                    Text = x.CategoryName,
                                    Value = x.CategoryName
                                }).ToList();
            var values = await _productService.GetProductByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index");
        }
    }
}
