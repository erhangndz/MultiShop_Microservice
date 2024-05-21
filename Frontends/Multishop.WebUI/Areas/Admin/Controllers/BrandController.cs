using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.BrandDtos;
using Multishop.WebUI.Services.CatalogServices.BrandServices;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
  
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BrandController(IBrandService _brandService) : Controller
    {
       
        public async Task<IActionResult> Index()
        {
            var values = await _brandService.GetAllBrandsAsync();
            return View(values);
        }

        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateBrandAsync(createBrandDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateBrand(string id)
        {
            var values = await _brandService.GetBrandByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _brandService.UpdateBrandAsync(updateBrandDto);
            return RedirectToAction("Index");
        }
    }
}
