using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.CategoryDtos;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CategoryController : Controller
    {
        private readonly HttpClient _client;

        public CategoryController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7060/api/");
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            string token ="";
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://localhost:5001/connect/token"),
                Method = HttpMethod.Post,
                Content = new FormUrlEncodedContent(new Dictionary<string, string> {
                    {   "client_id","MultishopVisitorId" },
                    {   "client_secret","multishopsecret" },
                    {   "grant_type","client_credentials" }
                })
            };

            var response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var tokenResponse = JObject.Parse(content);
                token = tokenResponse["access_token"].ToString();
            }
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var values = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");
            return View(values);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _client.PostAsJsonAsync("categories", createCategoryDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _client.DeleteAsync("categories/" + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCategory(string id)
        {
            var values = await _client.GetFromJsonAsync<UpdateCategoryDto>("categories/"+id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _client.PutAsJsonAsync("categories", updateCategoryDto);
            return RedirectToAction("Index");
        }
    }
}
