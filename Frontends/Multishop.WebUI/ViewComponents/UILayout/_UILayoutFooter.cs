using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.AboutDtos;
using Multishop.WebUI.Services.CatalogServices.AboutServices;
using Multishop.WebUI.Settings;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.ViewComponents.UILayout
{
    public class _UILayoutFooter(IAboutService _aboutService): ViewComponent
    {    
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutService.GetAllAboutsAsync();
            return View(values);
        }
    }
}
