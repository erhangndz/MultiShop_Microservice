using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.ProductDtos;

namespace Multishop.WebUI.ViewComponents.Shop
{
    public class _ShopFilteredProductList : ViewComponent
    {
        private readonly HttpClient _client;

        public _ShopFilteredProductList(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            id = ViewBag.id;

            if (id == null)
            {
                var values = await _client.GetFromJsonAsync<List<ResultProductDto>>("products");
                return View(values);
            }
            else
            {
                var values = await _client.GetFromJsonAsync<List<ResultProductDto>>("products/getProductsByCategoryId/" + id);
                return View(values);
            }


        }
    }
}
