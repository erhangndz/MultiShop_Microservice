using MediatR;
using Multishop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Application.MappingConfigs;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class CreateOrderingCommandHandler(IRepository<Ordering> repository) : IRequestHandler<CreateOrderingCommand>
    {
        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            await repository.CreateAsync(ObjectMapper.Mapper.Map<Ordering>(request));
        }
    }
}
