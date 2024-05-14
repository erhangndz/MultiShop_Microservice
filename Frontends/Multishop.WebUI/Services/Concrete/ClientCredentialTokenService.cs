using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using Multishop.WebDTO.DTOs.IdentityDtos;
using Multishop.WebUI.Models;
using Multishop.WebUI.Services.Interfaces;
using Multishop.WebUI.Settings;

namespace Multishop.WebUI.Services.Concrete
{
    public class ClientCredentialTokenService(HttpClient _client, IOptions<ServiceApiSettings> _serviceApiSettings, IClientAccessTokenCache _clientAccessTokenCache, IOptions<ClientSettings> _clientSettings) : IClientCredentialTokenService
    {

        public async Task<string> GetToken()
        {
            var currentToken = await _clientAccessTokenCache.GetAsync(_clientSettings.Value.MultishopVisitorClient.ToString());
            
            if(currentToken != null)
            {
                return currentToken.AccessToken;
            }

            var discoveryEndpoint = await _client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.Value.IdentityServerUrl
            });

            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.Value.MultishopVisitorClient.ClientId,
                ClientSecret = _clientSettings.Value.MultishopVisitorClient.ClientSecret,
                Address = discoveryEndpoint.TokenEndpoint
            };

            var newToken = await _client.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);

            await _clientAccessTokenCache.SetAsync(_clientSettings.Value.MultishopVisitorClient.ToString(), newToken.AccessToken,newToken.ExpiresIn);

            return newToken.AccessToken;




        }
    }
}
