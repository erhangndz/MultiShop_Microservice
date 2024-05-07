using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.SpecialOfferDtos;
using Multishop.WebUI.Settings;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeSpecialOffer:ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeSpecialOffer(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            var token = VisitorToken.CreateToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var values = await _client.GetFromJsonAsync<List<ResultSpecialOfferDto>>("specialOffers");
            return View(values);
        }
    }
}
