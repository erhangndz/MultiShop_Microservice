using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.FeatureServiceDtos;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class FeatureServiceController : Controller
    {
        private readonly HttpClient _client;

        public FeatureServiceController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }
       

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultFeatureServiceDto>>("featureServices");
            return View(values);
        }

        public IActionResult CreateFeatureService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureService(CreateFeatureServiceDto createFeatureServiceDto)
        {
            await _client.PostAsJsonAsync("featureServices", createFeatureServiceDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFeatureService(string id)
        {
            await _client.DeleteAsync("featureServices/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateFeatureService(string id)
        {
            var values = await _client.GetFromJsonAsync<UpdateFeatureServiceDto>("featureServices/" + id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeatureService(UpdateFeatureServiceDto updateFeatureServiceDto)
        {
            await _client.PutAsJsonAsync("featureServices", updateFeatureServiceDto);
            return RedirectToAction("Index");
        }
    }
}
