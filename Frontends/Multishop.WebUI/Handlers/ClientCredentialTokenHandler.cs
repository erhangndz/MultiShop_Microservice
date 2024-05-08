
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Multishop.WebUI.Services.Interfaces;
using System.Net;
using System.Net.Http.Headers;

namespace Multishop.WebUI.Handlers
{
    public class ClientCredentialTokenHandler(IClientCredentialTokenService _clientCredentialTokenService): DelegatingHandler
    {
       
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _clientCredentialTokenService.GetToken();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",token);
            var response=await base.SendAsync(request, cancellationToken);
           if(response.StatusCode==HttpStatusCode.Unauthorized)
            {
              throw new Exception(response.StatusCode.ToString());
            }
            return response;

        }

    }
}
