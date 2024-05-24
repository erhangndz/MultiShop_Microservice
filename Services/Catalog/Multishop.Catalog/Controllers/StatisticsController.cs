using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Services.StatisticsServices;

namespace Multishop.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatisticsController(IStatisticsService _statisticsService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _statisticsService.GetBrandCountAsync();
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryCount()
        {
            var values = await _statisticsService.GetCategoryCountAsync();
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductCount()
        {
            var values = await _statisticsService.GetProductCountAsync();
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetAvgProductPrice()
        {
            var values = await _statisticsService.GetAvgProductPriceAsync();
            return Ok(values);
        }
    }
}
