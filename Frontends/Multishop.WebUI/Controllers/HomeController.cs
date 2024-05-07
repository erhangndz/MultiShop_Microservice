using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.Controllers
{
    public class HomeController(HttpClient _client) : Controller
    {
        public async Task<IActionResult> Index()
        {
            string token;
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
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
               var tokenResponse= JObject.Parse(content);
                token = tokenResponse["access_token"].ToString();
            }

            return View();
        }
    }
}
