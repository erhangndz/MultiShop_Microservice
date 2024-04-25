using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.OfferDiscountDtos;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeOfferDiscount:ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeOfferDiscount(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultOfferDiscountDto>>("offerDiscounts");
            return View(values);
        }
    }
}
