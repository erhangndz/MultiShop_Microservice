using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multishop.WebDTO.DTOs.CatalogDtos.CategoryDtos;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductDtos;


namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProductController : Controller
    {
        private readonly HttpClient _client;

        public ProductController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultProductDto>>("products");
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
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
            

            await _client.PostAsJsonAsync("products", createProductDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _client.DeleteAsync("products/" + id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
            ViewBag.category = (from x in categoryList
                                select new SelectListItem
                                {
                                    Text = x.CategoryName,
                                    Value = x.CategoryName
                                }).ToList();
            var values = await _client.GetFromJsonAsync<UpdateProductDto>("products/" + id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _client.PutAsJsonAsync("products", updateProductDto);
            return RedirectToAction("Index");
        }
    }
}
