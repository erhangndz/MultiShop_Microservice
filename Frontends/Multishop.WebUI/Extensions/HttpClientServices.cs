using Microsoft.CodeAnalysis.CSharp.Syntax;
using Multishop.WebUI.Handlers;
using Multishop.WebUI.Services.CatalogServices.AboutServices;
using Multishop.WebUI.Services.CatalogServices.CategoryServices;
using Multishop.WebUI.Services.CatalogServices.ProductDetailServices;
using Multishop.WebUI.Services.CatalogServices.ProductPhotoServices;
using Multishop.WebUI.Services.CatalogServices.ProductServices;
using Multishop.WebUI.Services.Concrete;
using Multishop.WebUI.Services.Interfaces;
using Multishop.WebUI.Settings;

namespace Multishop.WebUI.Extensions
{
    public static class HttpClientServices
    {


        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();
            services.AddHttpClient<IIdentityService, IdentityService>();


            var serviceApiSettings = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

            services.AddHttpClient<IUserService, UserService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.IdentityServerUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

           

            services.AddHttpClient<ICategoryService, CategoryService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();


            services.AddHttpClient<IProductService, ProductService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IProductDetailService, ProductDetailService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IProductPhotoService, ProductPhotoService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IAboutService, AboutService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        }

    }
}
