using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.AboutDtos;
using Multishop.WebUI.Services.CatalogServices.AboutServices;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutController(IAboutService _aboutService) : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            var values = await _aboutService.GetAllAboutsAsync();
            return View(values);
        }

        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateAbout(string id)
        {
            var values = await _aboutService.GetAboutByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction("Index");
        }
    }
}
