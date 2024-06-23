using MassTransit;
using Multishop.SharedLibrary.RabbitMQEvents;
using Multishop.WebUI.Services.BasketServices;

namespace Multishop.WebUI.Consumers
{
    public class ProductNameChangedEventConsumer(IBasketService _basketService) : IConsumer<ProductNameChangedEvent>
    {
        public async Task Consume(ConsumeContext<ProductNameChangedEvent> context)
        {
           

            var basketItems = await _basketService.GetBasketAsync();

           

            foreach (var x in basketItems.BasketItems)
            {
                if (x.ProductId == context.Message.ProductId)
                {
                    x.ProductId = context.Message.ProductId;
                    x.ProductName = context.Message.UpdatedName;
                    x.Price=context.Message.UpdatedPrice;
                  
                }

            }

            await _basketService.SaveBasketAsync(basketItems);


        }
    }
}
