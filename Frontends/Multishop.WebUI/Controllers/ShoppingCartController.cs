using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.BasketDtos;
using Multishop.WebUI.Services.BasketServices;
using Multishop.WebUI.Services.CatalogServices.ProductServices;
using Multishop.WebUI.Services.DiscountServices;
using Multishop.WebUI.ViewComponents.Contact;

namespace Multishop.WebUI.Controllers
{
    public class ShoppingCartController(IBasketService _basketService,IProductService _productService,IDiscountService _discountService) : Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }


        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetProductByIdAsync(id);

            var items = new BasketItemDto
            {
                ProductId = id,
                ProductName = values.ProductName,
                ImageUrl= values.ImageUrl,
                Price = values.Price,
                Quantity = 1
            };

            await _basketService.AddBasketItemAsync(items);
            return RedirectToAction("Index","ShoppingCart");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItemAsync(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ApplyCoupon(string code)
        {
            var coupon = await _discountService.GetCouponByCodeAsync(code);
            if(coupon != null)
            {
                var basket1 = await _basketService.GetBasketAsync();
                basket1.DiscountCode = coupon.Code;
                basket1.DiscountRate = coupon.Rate;
                await _basketService.SaveBasketAsync(basket1);
            }

            var basket = await _basketService.GetBasketAsync();
            basket.DiscountCode = "";
            basket.DiscountRate = 0;
            await _basketService.SaveBasketAsync(basket);
            return RedirectToAction("Index");
            
        }
    }
}
