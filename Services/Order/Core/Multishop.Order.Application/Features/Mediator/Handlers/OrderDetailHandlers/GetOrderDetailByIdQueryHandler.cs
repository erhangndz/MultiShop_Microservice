using MediatR;
using Multishop.Order.Application.Features.Mediator.Queries.OrderDetailQueries;
using Multishop.Order.Application.Features.Mediator.Results.OrderDetailResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Application.MappingConfigs;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository) : IRequestHandler<GetOrderDetailByIdQuery, GetOrderDetailByIdQueryResult>
    {
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
        {
            return ObjectMapper.Mapper.Map<GetOrderDetailByIdQueryResult>(await repository.GetByIdAsync(request.Id));
        }
    }
}
