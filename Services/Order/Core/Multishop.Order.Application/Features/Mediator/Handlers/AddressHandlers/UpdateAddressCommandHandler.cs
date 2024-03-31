using AutoMapper.Internal.Mappers;
using MediatR;
using Multishop.Order.Application.Features.Mediator.Commands.AddressCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Application.MappingConfigs;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler(IRepository<Address> repository) : IRequestHandler<UpdateAddressCommand>
    {
        public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
           
            await repository.UpdateAsync(ObjectMapper.Mapper.Map<Address>(request));
        }
    }
}
