using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.CatalogDtos.CategoryDtos;
using Multishop.WebUI.Services.CatalogServices.CategoryServices;
using Multishop.WebUI.Settings;
using Newtonsoft.Json.Linq;

namespace Multishop.WebUI.ViewComponents.Home
{
    public class _HomeCategories(ICategoryService _categoryService): ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var values = await _categoryService.GetAllCategoriesAsync();
            return View(values);
        }
    }
}
