using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.BrandDtos;
using Multishop.WebUI.Services.Interfaces;
using Multishop.WebUI.Settings;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeBrands:ViewComponent
    {
        private readonly HttpClient _client;
       


        public _HomeBrands(HttpClient client)
        {
            
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            var token = VisitorToken.CreateToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            _client = client;
           
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var values = await _client.GetFromJsonAsync<List<ResultBrandDto>>("brands");
            return View(values);
        }
    }
}
