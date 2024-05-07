using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductDetailDtos;
using Multishop.WebUI.Settings;

namespace Multishop.WebUI.ViewComponents.ProductDetails
{
    public class _ProductDetailInformation:ViewComponent
    {
        private readonly HttpClient _client;

        public _ProductDetailInformation(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            var token = VisitorToken.CreateToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultProductDetailDto>>("productDetails/getDetailsByProductId/" + id);
            return View(values);
        }
       
    }
}
