using Microsoft.CodeAnalysis.CSharp.Syntax;
using Multishop.SignalRRealTimeApi.Services;
using Multishop.WebUI.Handlers;
using Multishop.WebUI.Services.BasketServices;
using Multishop.WebUI.Services.CargoServices.CargoCustomerServices;
using Multishop.WebUI.Services.CargoServices.CompanyServices;
using Multishop.WebUI.Services.CatalogServices.AboutServices;
using Multishop.WebUI.Services.CatalogServices.BrandServices;
using Multishop.WebUI.Services.CatalogServices.CategoryServices;
using Multishop.WebUI.Services.CatalogServices.ContactServices;
using Multishop.WebUI.Services.CatalogServices.FeatureServiceServices;
using Multishop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Multishop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Multishop.WebUI.Services.CatalogServices.ProductDetailServices;
using Multishop.WebUI.Services.CatalogServices.ProductPhotoServices;
using Multishop.WebUI.Services.CatalogServices.ProductServices;
using Multishop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Multishop.WebUI.Services.CommentServices;
using Multishop.WebUI.Services.Concrete;
using Multishop.WebUI.Services.DiscountServices;
using Multishop.WebUI.Services.Interfaces;
using Multishop.WebUI.Services.MessageServices;
using Multishop.WebUI.Services.OrderServices.AddressServices;
using Multishop.WebUI.Services.OrderServices.OrderDetailServices;
using Multishop.WebUI.Services.OrderServices.OrderingServices;
using Multishop.WebUI.Services.StatisticsServices.CatalogStatisticsServices;
using Multishop.WebUI.Services.StatisticsServices.CommentStatisticsServices;
using Multishop.WebUI.Services.StatisticsServices.MessageStatisticsServices;
using Multishop.WebUI.Services.StatisticsServices.UserStatisticsService;
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

            services.AddHttpClient<IBrandService, BrandService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IFeatureServiceService, FeatureServiceService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IOfferDiscountService, OfferDiscountService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IContactService, ContactService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<ICommentService, CommentService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Comment.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IBasketService, BasketService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Basket.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IDiscountService, DiscountService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Discount.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IAddressService, AddressService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Order.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IOrderingService, OrderingService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Order.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IMessageService, MessageService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Message.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IOrderDetailService, OrderDetailService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Order.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<ICompanyService, CompanyService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Cargo.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<ICargoCustomerService, CargoCustomerService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Cargo.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<ICatalogStatisticsService, CatalogStatisticsService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IUserStatisticsService, UserStatisticsService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.IdentityServerUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<ICommentStatisticsService, CommentStatisticsService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl+serviceApiSettings.Comment.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IMessageStatisticsService, MessageStatisticsService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.GatewayUrl + serviceApiSettings.Message.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<ISignalRService, SignalRService>().AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();



        }

    }
}
