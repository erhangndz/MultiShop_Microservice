using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.CategoryDtos;

namespace Multishop.WebUI.ViewComponents.UILayout
{
    public class _UILayoutNavbar:ViewComponent
    {
        private readonly HttpClient _client;

        public _UILayoutNavbar(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }

     
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
            return View(values);
        }
    }
}
