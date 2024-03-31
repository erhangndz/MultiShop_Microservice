using MediatR;
using Multishop.Order.Application.Features.Mediator.Queries.OrderDetailQueries;
using Multishop.Order.Application.Features.Mediator.Results.OrderDetailResults;
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
    public class GetOrderDetailQueryHandler(IRepository<OrderDetail> repository) : IRequestHandler<GetOrderDetailQuery, List<GetOrderDetailQueryResult>>
    {
        public async Task<List<GetOrderDetailQueryResult>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
          
            return ObjectMapper.Mapper.Map<List<GetOrderDetailQueryResult>>(await repository.GetAllAsync());
        }
    }
}
