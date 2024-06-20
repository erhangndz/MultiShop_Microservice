using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using Multishop.WebUI.Areas.Admin.Models;
using Newtonsoft.Json;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class RapidApiController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> ECommerceList()
        {







            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-product-search.p.rapidapi.com/search?q=Nike%20shoes&country=tr&language=tr&limit=30&sort_by=BEST_MATCH&product_condition=ANY&min_rating=ANY"),
                Headers =
    {
        { "x-rapidapi-key", "e782ab3024msh2e78af442950fd0p115136jsnc3dd0b8c5f54" },
        { "x-rapidapi-host", "real-time-product-search.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ProductSearchViewModel>(body);

                var productList = values.data.ToList();
                

                return View(values.data.ToList());
            }

        }


        [HttpPost]
        public async Task<IActionResult> ECommerceList(string productName)
        {







            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://real-time-product-search.p.rapidapi.com/search?q={productName}&country=tr&language=tr&limit=30&sort_by=BEST_MATCH&product_condition=ANY&min_rating=ANY"),
                Headers =
    {
        { "x-rapidapi-key", "e782ab3024msh2e78af442950fd0p115136jsnc3dd0b8c5f54" },
        { "x-rapidapi-host", "real-time-product-search.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ProductSearchViewModel>(body);

                var productList = values.data.ToList();


                return View(values.data.ToList());
            }

        }
    }
}
