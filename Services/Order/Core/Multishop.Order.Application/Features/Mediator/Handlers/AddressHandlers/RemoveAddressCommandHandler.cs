using MediatR;
using Multishop.Order.Application.Features.Mediator.Commands.AddressCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class RemoveAddressCommandHandler(IRepository<Address> repository) : IRequestHandler<RemoveAddressCommand>
    {
        public async Task Handle(RemoveAddressCommand request, CancellationToken cancellationToken)
        {
            await repository.DeleteAsync(request.Id);
        }
    }
}
