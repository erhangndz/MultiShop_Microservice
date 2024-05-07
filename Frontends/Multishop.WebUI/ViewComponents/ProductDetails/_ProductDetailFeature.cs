using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductDtos;
using Multishop.WebUI.Settings;

namespace Multishop.WebUI.ViewComponents.ProductDetails
{
    public class _ProductDetailFeature: ViewComponent
    {
        private readonly HttpClient _client;

        public _ProductDetailFeature(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            var token = VisitorToken.CreateToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _client.GetFromJsonAsync<ResultProductDto>("products/" + id);
            return View(values);
           
        }
    }
}
