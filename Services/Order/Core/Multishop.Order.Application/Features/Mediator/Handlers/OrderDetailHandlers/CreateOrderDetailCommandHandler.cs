using MediatR;
using Multishop.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Application.MappingConfigs;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository) : IRequestHandler<CreateOrderDetailCommand>
    {
        public async Task Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(ObjectMapper.Mapper.Map<OrderDetail>(request));
        }
    }
}
