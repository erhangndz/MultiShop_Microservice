using Multishop.WebUI.Models;
using Multishop.WebUI.Services.Interfaces;

namespace Multishop.WebUI.Services.Concrete
{
    public class ClientCredentialTokenService(HttpClient client) : IClientCredentialTokenService
    {

        public async Task<string> GetToken()
        {
           var values = await  client.GetFromJsonAsync<TokenViewModel>("/connect/token");

            return values.access_token;
         
        }
    }
}
