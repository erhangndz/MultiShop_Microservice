using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.BasketDtos;
using Multishop.WebUI.Services.BasketServices;
using Multishop.WebUI.Services.CatalogServices.ProductServices;

namespace Multishop.WebUI.Controllers
{
    public class ShoppingCartController(IBasketService _basketService,IProductService _productService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await _basketService.GetBasketAsync();
            return View(values);
        }


        public async Task<IActionResult> AddBasketItem(string productId)
        {
            var values = await _productService.GetProductByIdAsync(productId);

            var items = new BasketItemDto
            {
                ProductId = values.Id,
                ProductName = values.ProductName,
                Price = values.Price,
                Quantity = 1
            };

            await _basketService.AddBasketItemAsync(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            await _basketService.RemoveBasketItemAsync(productId);
            return RedirectToAction("Index");
        }
    }
}
