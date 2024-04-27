using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductPhotoDtos;

namespace Multishop.WebUI.ViewComponents.ProductDetails
{
    public class _ProductDetailCarousel:ViewComponent
    {
        private readonly HttpClient _client;

        public _ProductDetailCarousel(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultProductPhotoDto>>("productphotos/getPhotosByProductId/" + id);
            return View(values);
        }
    }
}
