using MediatR;
using Multishop.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Application.MappingConfigs;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository) : IRequestHandler<UpdateOrderDetailCommand>
    {
        public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            await repository.UpdateAsync(ObjectMapper.Mapper.Map<OrderDetail>(request));
        }
    }
}
