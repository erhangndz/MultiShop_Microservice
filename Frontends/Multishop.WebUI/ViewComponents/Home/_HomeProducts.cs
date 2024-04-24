using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductDtos;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeProducts:ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeProducts(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultProductDto>>("products");
            return View(values);
        }
    }
}
