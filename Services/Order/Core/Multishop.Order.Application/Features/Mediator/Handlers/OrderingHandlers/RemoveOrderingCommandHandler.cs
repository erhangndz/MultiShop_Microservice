using MediatR;
using Multishop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class RemoveOrderingCommandHandler(IRepository<Ordering> repository) : IRequestHandler<RemoveOrderingCommand>
    {
        public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
        {
            await repository.DeleteAsync(request.Id);
        }
    }
}
