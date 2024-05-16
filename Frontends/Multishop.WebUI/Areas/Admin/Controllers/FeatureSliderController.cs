using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.FeatureSliderDtos;
using Multishop.WebUI.Services.CatalogServices.FeatureSliderServices;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class FeatureSliderController(IFeatureSliderService _featureSliderService) : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            var values = await _featureSliderService.GetAllFeatureSlidersAsync();
            return View(values);
        }

        public IActionResult CreateFeatureSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            var values = await _featureSliderService.GetFeatureSliderByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ShowOnHome(string id)
        {
            await _featureSliderService.ShowOnHomeAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DontShowOnHome(string id)
        {
            await _featureSliderService.DontShowOnHomeAsync(id);
            return RedirectToAction("Index");
        }
    }
}
