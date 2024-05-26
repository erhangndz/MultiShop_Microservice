using Microsoft.AspNetCore.Mvc;
using Multishop.WebUI.Services.DiscountServices;
using Multishop.WebUI.Services.StatisticsServices.CatalogStatisticsServices;
using Multishop.WebUI.Services.StatisticsServices.CommentStatisticsServices;
using Multishop.WebUI.Services.StatisticsServices.MessageStatisticsServices;
using Multishop.WebUI.Services.StatisticsServices.UserStatisticsService;

namespace Multishop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class StatisticController(ICatalogStatisticsService _catalogStatisticsService,IUserStatisticsService _userStatisticsService,ICommentStatisticsService _commentStatisticsService,IDiscountService _discountService,IMessageStatisticsService _messageStatisticsService) : Controller
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
            ViewBag.activeCommentCount= await _commentStatisticsService.GetActiveCommentCountAsync();
            ViewBag.passiveCommentCount= await _commentStatisticsService.GetPassiveCommentCountAsync();
            ViewBag.totalCommentCount= await _commentStatisticsService.GetTotalCommentCountAsync();
            ViewBag.couponCount= await _discountService.GetCouponCountAsync();
            ViewBag.messageCount= await _messageStatisticsService.GetTotalMessageCountAsync();
            return View();
        }
    }
}


