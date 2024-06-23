using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Multishop.WebDTO.DTOs.CatalogDtos.CategoryDtos;
using Multishop.WebUI.Controllers;
using Multishop.WebUI.Services.CatalogServices.CategoryServices;
using Multishop.WebUI.Settings;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.ViewComponents.UILayout
{
    public class _UILayoutNavbar(ICategoryService _categoryService, IStringLocalizer<_UILayoutNavbar> _localizer) :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoriesAsync();
            return View(values);
        }
    }
}
