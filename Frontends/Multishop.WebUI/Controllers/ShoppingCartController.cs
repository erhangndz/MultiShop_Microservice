using Microsoft.AspNetCore.Mvc;
using Multishop.WebDTO.DTOs.BasketDtos;
using Multishop.WebUI.Services.BasketServices;
using Multishop.WebUI.Services.CatalogServices.ProductServices;

namespace Multishop.WebUI.Controllers
{
    public class ShoppingCartController(IBasketService _basketService,IProductService _productService) : Controller
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
    }
}
