using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.BrandDtos;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BrandController : Controller
    {
        private readonly HttpClient _client;

        public BrandController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBrandDto>>("brands");
            return View(values);
        }

        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _client.PostAsJsonAsync("brands", createBrandDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _client.DeleteAsync("brands/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateBrand(string id)
        {
            var values = await _client.GetFromJsonAsync<UpdateBrandDto>("brands/" + id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _client.PutAsJsonAsync("brands", updateBrandDto);
            return RedirectToAction("Index");
        }
    }
}
