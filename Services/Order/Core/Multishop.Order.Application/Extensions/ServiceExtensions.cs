using Microsoft.Extensions.DependencyInjection;
using Multishop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

namespace Multishop.Order.Application.Extensions
{
    public static class ServiceExtensions
    {

        public static void AddApplicationExtensions(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<CreateOrderingCommandHandler>();
            });
        }
    }
}
