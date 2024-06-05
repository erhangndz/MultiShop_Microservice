using IdentityModel.AspNetCore.AccessTokenManagement;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using Multishop.WebUI.ConfigOptions;
using Multishop.WebUI.Extensions;
using Multishop.WebUI.Handlers;
using Multishop.WebUI.Hubs;
using Multishop.WebUI.Services.CatalogServices.CategoryServices;
using Multishop.WebUI.Services.Concrete;
using Multishop.WebUI.Services.ImageServices;
using Multishop.WebUI.Services.Interfaces;
using Multishop.WebUI.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .SetIsOriginAllowed((host) => true)
               .AllowCredentials();
    });
});


builder.Services.Configure<GCSConfigOptions>(builder.Configuration);
builder.Services.AddSingleton<ICloudStorageService, CloudStorageService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index";
    opt.LogoutPath = "/Login/Logout";
    opt.AccessDeniedPath="/Pages/AccessDenied";
    opt.Cookie.SameSite=SameSiteMode.Strict;
    opt.Cookie.SecurePolicy= CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "MultishopJwt";
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index";
    opt.ExpireTimeSpan = TimeSpan.FromDays(5);
    opt.Cookie.Name = "MultishopCookie";
    opt.SlidingExpiration = true;
});

builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection(nameof(ClientSettings)));
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection(nameof(ServiceApiSettings)));

builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddAccessTokenManagement();
builder.Services.AddHttpClientServices(builder.Configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();


builder.Services.AddControllersWithViews(o =>
{
    o.Filters.Add(new AuthorizeFilter());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.MapHub<SignalRHub>("/signalrhub");
app.Run();
