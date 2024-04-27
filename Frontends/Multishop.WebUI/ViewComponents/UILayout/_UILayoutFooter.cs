using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.AboutDtos;

namespace Multishop.WebUI.ViewComponents.UILayout
{
    public class _UILayoutFooter: ViewComponent
    {
        private readonly HttpClient _client;

        public _UILayoutFooter(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(values);
        }
    }
}
