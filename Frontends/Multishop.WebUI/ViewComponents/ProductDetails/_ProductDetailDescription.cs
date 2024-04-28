using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductDetailDtos;

namespace Multishop.WebUI.ViewComponents.ProductDetails
{
    public class _ProductDetailDescription:ViewComponent
    {
        private readonly HttpClient _client;

        public _ProductDetailDescription(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultProductDetailDto>>("productDetails/getDetailsByProductId/" + id);
            return View(values);
        }
    }
}
