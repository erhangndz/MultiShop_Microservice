using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductDetailDtos;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductDtos;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProductDetailController : Controller
    {
        private readonly HttpClient _client;

        public ProductDetailController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }
       public async Task<IActionResult> Details(string id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultProductDetailDto>>("productDetails/getDetailsByProductId/" + id);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateDetail()
        {

            var productList = await _client.GetFromJsonAsync<List<ResultProductDto>>("products");
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
            await _client.PostAsJsonAsync("productDetails", createProductDetailDto);
            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public  async Task<IActionResult> UpdateDetail(string id)
        {
            var values = await _client.GetFromJsonAsync<UpdateProductDetailDto>("productDetails/" + id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _client.PutAsJsonAsync("productDetails", updateProductDetailDto);
            return RedirectToAction("Index", "Product");
        }
    }
}
