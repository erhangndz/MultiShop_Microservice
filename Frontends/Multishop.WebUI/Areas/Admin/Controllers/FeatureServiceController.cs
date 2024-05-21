using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.FeatureServiceDtos;
using Multishop.WebUI.Services.CatalogServices.FeatureServiceServices;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class FeatureServiceController(IFeatureServiceService _featureServiceService) : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            var values = await _featureServiceService.GetAllFeatureServicesAsync();
            return View(values);
        }

        public IActionResult CreateFeatureService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureService(CreateFeatureServiceDto createFeatureServiceDto)
        {
            await _featureServiceService.CreateFeatureServiceAsync(createFeatureServiceDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteFeatureService(string id)
        {
            await _featureServiceService.DeleteFeatureServiceAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateFeatureService(string id)
        {
            var values = await _featureServiceService.GetFeatureServiceByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeatureService(UpdateFeatureServiceDto updateFeatureServiceDto)
        {
            await _featureServiceService.UpdateFeatureServiceAsync(updateFeatureServiceDto);
            return RedirectToAction("Index");
        }
    }
}
