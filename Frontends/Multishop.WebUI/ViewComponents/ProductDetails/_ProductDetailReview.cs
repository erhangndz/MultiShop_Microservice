using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CommentDtos;
using Multishop.WebUI.Settings;

namespace Multishop.WebUI.ViewComponents.ProductDetails
{

    public class _ProductDetailReview:ViewComponent
    {
        private readonly HttpClient _client;

        public _ProductDetailReview(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7016/api/");
            var token = VisitorToken.CreateToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            _client = client;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            ViewBag.ProductId = id;
            var values = await _client.GetFromJsonAsync<List<ResultCommentDto>>("comments/getByProductId/" + id);
            return View(values);
        }
    }
}
