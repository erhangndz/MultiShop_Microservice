using MediatR;
using Multishop.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository) : IRequestHandler<RemoveOrderDetailCommand>
    {
        public async Task Handle(RemoveOrderDetailCommand request, CancellationToken cancellationToken)
        {
            await repository.DeleteAsync(request.Id);
        }
    }
}
