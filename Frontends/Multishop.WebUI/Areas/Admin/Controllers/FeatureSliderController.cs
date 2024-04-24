using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.FeatureSliderDtos;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class FeatureSliderController : Controller
    {
        private readonly HttpClient _client;

        public FeatureSliderController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultFeatureSliderDto>>("featureSliders");
            return View(values);
        }

        public IActionResult CreateFeatureSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _client.PostAsJsonAsync("featureSliders", createFeatureSliderDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _client.DeleteAsync("featureSliders/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            var values = await _client.GetFromJsonAsync<UpdateFeatureSliderDto>("featureSliders/" + id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _client.PutAsJsonAsync("featureSliders", updateFeatureSliderDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShowOnHome(string id)
        {
            await _client.GetAsync("featureSliders/ShowOnHome/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(string id)
        {
            await _client.GetAsync("featureSliders/DontShowOnHome/" + id);
            return RedirectToAction("Index");
        }
    }
}
