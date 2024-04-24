using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.FeatureServiceDtos;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeService: ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultFeatureServiceDto>>("featureServices");
            return View(values);
        }
    }
}
