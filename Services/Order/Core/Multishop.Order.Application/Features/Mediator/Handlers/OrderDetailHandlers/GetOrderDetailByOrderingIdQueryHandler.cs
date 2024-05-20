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
    public class GetOrderDetailByOrderingIdQueryHandler(IRepository<OrderDetail> _repository) : IRequestHandler<GetOrderDetailByOrderingIdQuery, List<GetOrderDetailByOrderingIdQueryResult>>
    {
        public async Task<List<GetOrderDetailByOrderingIdQueryResult>> Handle(GetOrderDetailByOrderingIdQuery request, CancellationToken cancellationToken)
        {
           return ObjectMapper.Mapper.Map<List<GetOrderDetailByOrderingIdQueryResult>>(await _repository.GetFilteredListAsync(x=>x.OrderingId== request.OrderingId));
        }
    }
}
