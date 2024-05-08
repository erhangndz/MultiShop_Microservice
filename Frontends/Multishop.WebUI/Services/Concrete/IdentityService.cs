using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Multishop.WebDTO.DTOs.IdentityDtos;
using Multishop.WebUI.Services.Interfaces;
using Multishop.WebUI.Settings;
using System.Security.Claims;

namespace Multishop.WebUI.Services.Concrete
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ClientSettings _clientSettings;
        private readonly ServiceApiSettings _serviceApiSettings;

        public IdentityService(HttpClient client, IHttpContextAccessor contextAccessor, IOptions<ClientSettings> clientSettings, IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _client = client;
            _contextAccessor = contextAccessor;
            _clientSettings = clientSettings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public async Task<bool> SignIn(SignInDto signInDto)
        {
            var discoveryEndpoint = await _client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl
            }) ;

            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId = _clientSettings.MultishopManagerClient.ClientId,
                ClientSecret = _clientSettings.MultishopManagerClient.ClientSecret,
                UserName = signInDto.UserName,
                Password = signInDto.Password,
                Address = discoveryEndpoint.TokenEndpoint
            };


            var token = await _client.RequestPasswordTokenAsync(passwordTokenRequest);

            var userInfoRequest = new UserInfoRequest
            {
                Address = discoveryEndpoint.UserInfoEndpoint,
                Token = token.AccessToken
            };

            var userValues = await _client.GetUserInfoAsync(userInfoRequest);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties();

            authenticationProperties.StoreTokens(new List<AuthenticationToken>(){
                new AuthenticationToken
                {
                    Name= OpenIdConnectParameterNames.AccessToken,
                    Value= token.AccessToken
                },
                new AuthenticationToken
                {
                    Name=OpenIdConnectParameterNames.RefreshToken,
                    Value= token.RefreshToken
                },

                new AuthenticationToken
                {
                    Name= OpenIdConnectParameterNames.ExpiresIn,
                    Value= DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }
            });

            authenticationProperties.IsPersistent = false;

            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal,authenticationProperties);

            return true;
        }
    }
}
