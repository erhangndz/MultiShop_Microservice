using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.FeatureSliderDtos;
using Multishop.WebUI.Settings;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeCarousel:ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeCarousel(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            var token = VisitorToken.CreateToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var values = await _client.GetFromJsonAsync<List<ResultFeatureSliderDto>>("featureSliders");
            return View(values);
        }
    }
}
