using MassTransit;
using Multishop.Basket.LoginServices;
using Multishop.Basket.Services;
using Multishop.SharedLibrary.RabbitMQEvents;

namespace Multishop.Basket.Consumers
{
    public class ProductNameChangedEventConsumer(IBasketService _basketService, ILoginService _loginService) : IConsumer<ProductNameChangedEvent>
    {
        public async Task Consume(ConsumeContext<ProductNameChangedEvent> context)
        {
            var basketItems =await _basketService.GetBasketAsync(_loginService.GetUserId);


            foreach (var item in basketItems.BasketItems)
            {
                if (item.ProductId == context.Message.ProductId)
                {
                    item.ProductName = context.Message.UpdatedName;
                    item.ProductId=context.Message.ProductId;
                    await _basketService.SaveBasketAsync(basketItems);
                }

            }
           

        }
    }
}
