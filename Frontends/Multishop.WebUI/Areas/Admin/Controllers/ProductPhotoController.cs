using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductDtos;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductPhotoDtos;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProductPhotoController : Controller
    {
        private readonly HttpClient _client;

        public ProductPhotoController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultProductPhotoDto>>("productPhotos");
            return View(values);
        }

        public async Task<IActionResult> GetPhotosByProductId(string id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultProductPhotoDto>>("productphotos/getPhotosByProductId/" + id);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProductPhoto()
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
        public async Task<IActionResult> CreateProductPhoto(CreateProductPhotoDto createProductPhotoDto)
        {
            await _client.PostAsJsonAsync("productPhotos", createProductPhotoDto);
            return RedirectToAction("Index","Product");
        }

        public async Task<IActionResult> DeleteProductPhoto(string id)
        {
            await _client.DeleteAsync("productPhotos/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateProductPhoto(string id)
        {
            var values = await _client.GetFromJsonAsync<UpdateProductPhotoDto>("productPhotos/" + id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductPhoto(UpdateProductPhotoDto updateProductPhotoDto)
        {
            await _client.PutAsJsonAsync("productPhotos", updateProductPhotoDto);
            return RedirectToAction("Index","Product");
        }
    }
}
