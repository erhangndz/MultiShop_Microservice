using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.OfferDiscountDtos;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class OfferDiscountController : Controller
    {
        private readonly HttpClient _client;

        public OfferDiscountController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultOfferDiscountDto>>("offerDiscounts");
            return View(values);
        }

        public IActionResult CreateOfferDiscount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _client.PostAsJsonAsync("offerDiscounts", createOfferDiscountDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _client.DeleteAsync("offerDiscounts/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            var values = await _client.GetFromJsonAsync<UpdateOfferDiscountDto>("offerDiscounts/" + id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _client.PutAsJsonAsync("offerDiscounts", updateOfferDiscountDto);
            return RedirectToAction("Index");
        }
    }
}
