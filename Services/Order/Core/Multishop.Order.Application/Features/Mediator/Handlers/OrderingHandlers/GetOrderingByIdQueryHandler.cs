using MediatR;
using Multishop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using Multishop.Order.Application.Features.Mediator.Results.OrderingResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Application.MappingConfigs;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler(IRepository<Ordering> repository) : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            return ObjectMapper.Mapper.Map<GetOrderingByIdQueryResult>(await repository.GetByIdAsync(request.Id));
        }
    }
}
