using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Multishop.WebDTO.DTOs.CatalogDtos.CategoryDtos;
using Multishop.WebUI.Settings;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CategoryController : Controller
    {
        private readonly HttpClient _client;
        private readonly ServiceApiSettings _serviceApiSettings;

        public CategoryController(HttpClient client, IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _serviceApiSettings = serviceApiSettings.Value;
            client.BaseAddress = new Uri(_serviceApiSettings.GatewayUrl+_serviceApiSettings.Catalog.Path);
            var token = VisitorToken.CreateToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            _client = client;
            
        }

        public async Task<IActionResult> Index()
        {
          
            var values = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
            return View(values);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _client.PostAsJsonAsync("categories", createCategoryDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _client.DeleteAsync("categories/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCategory(string id)
        {
            var values = await _client.GetFromJsonAsync<UpdateCategoryDto>("categories/"+id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _client.PutAsJsonAsync("categories", updateCategoryDto);
            return RedirectToAction("Index");
        }
    }
}
