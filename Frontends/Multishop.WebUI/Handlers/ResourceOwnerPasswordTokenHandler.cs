
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Multishop.WebUI.Services.Interfaces;
using System.Net;
using System.Net.Http.Headers;

namespace Multishop.WebUI.Handlers
{
    public class ResourceOwnerPasswordTokenHandler(IHttpContextAccessor httpContextAccessor,IIdentityService identityService): DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessToken = await httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            request.Headers.Authorization=new AuthenticationHeaderValue("Bearer",accessToken);

            var response = await base.SendAsync(request, cancellationToken);

            if(response.StatusCode==HttpStatusCode.Unauthorized)
            {
                var tokenResponse = await identityService.GetRefreshToken();
                if (tokenResponse == true)
                {
                    request.Headers.Authorization= new AuthenticationHeaderValue("Bearer", accessToken);
                    response = await base.SendAsync(request, cancellationToken);
                }
            }

            if(response.StatusCode==HttpStatusCode.Unauthorized)
            {
                throw new Exception(response.StatusCode.ToString());

            }
            return response;
        }

    }
}
