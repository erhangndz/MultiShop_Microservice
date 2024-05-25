using Microsoft.AspNetCore.Mvc;
using Multishop.WebUI.Services.StatisticsServices.CatalogStatisticsServices;
using Multishop.WebUI.Services.StatisticsServices.UserStatisticsService;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class StatisticController(ICatalogStatisticsService _catalogStatisticsService,IUserStatisticsService _userStatisticsService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.brandCount= await _catalogStatisticsService.GetBrandCountAsync();
            ViewBag.categoryCount= await _catalogStatisticsService.GetCategoryCountAsync();
            ViewBag.productCount= await _catalogStatisticsService.GetProductCountAsync();
            //ViewBag.avgProductPrice= await _catalogStatisticsService.GetAvgProductPriceAsync();
            ViewBag.cheapestProduct= await _catalogStatisticsService.GetCheapestProductName();
            ViewBag.expensiveProduct= await _catalogStatisticsService.GetMostExpensiveProductName();
            ViewBag.userCount= await _userStatisticsService.GetUserCountAsync();
            return View();
        }
    }
}


