using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.SpecialOfferDtos;
using Multishop.WebUI.Services.CatalogServices.SpecialOfferServices;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
 
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class SpecialOfferController(ISpecialOfferService _specialOfferService) : Controller
    {
       
        public async Task<IActionResult> Index()
        {
            var values = await _specialOfferService.GetAllSpecialOffersAsync();
            return View(values);
        }

        public IActionResult CreateSpecialOffer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            var values = await _specialOfferService.GetSpecialOfferByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return RedirectToAction("Index");
        }
    }
}
