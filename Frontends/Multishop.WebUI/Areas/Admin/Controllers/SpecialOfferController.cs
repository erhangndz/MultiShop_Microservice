using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.SpecialOfferDtos;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class SpecialOfferController : Controller
    {
        private readonly HttpClient _client;

        public SpecialOfferController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSpecialOfferDto>>("specialOffers");
            return View(values);
        }

        public IActionResult CreateSpecialOffer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _client.PostAsJsonAsync("specialOffers", createSpecialOfferDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _client.DeleteAsync("specialOffers/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            var values = await _client.GetFromJsonAsync<UpdateSpecialOfferDto>("specialOffers/" + id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _client.PutAsJsonAsync("specialOffers", updateSpecialOfferDto);
            return RedirectToAction("Index");
        }
    }
}
