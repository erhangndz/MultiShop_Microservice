using Newtonsoft.Json.Linq;
using System.Drawing.Text;
using System.Net.Http.Headers;

namespace Multishop.WebUI.Settings
{
    public static class VisitorToken
    {

      

        public static string CreateToken()
        {
            var _client = new HttpClient();
            
            string token = "";
            
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

            var response =  _client.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                var content =  response.Content.ReadAsStringAsync().Result;
                var tokenResponse = JObject.Parse(content);
                token = tokenResponse["access_token"].ToString();
            }

            return token;


       
        }

    }
}
