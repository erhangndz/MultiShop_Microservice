using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.OfferDiscountDtos;
using Multishop.WebUI.Services.CatalogServices.OfferDiscountServices;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class OfferDiscountController(IOfferDiscountService _offerDiscountService) : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            var values = await _offerDiscountService.GetAllOfferDiscountsAsync();
            return View(values);
        }

        public IActionResult CreateOfferDiscount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            var values = await _offerDiscountService.GetOfferDiscountByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return RedirectToAction("Index");
        }
    }
}
