using MediatR;
using Multishop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using Multishop.Order.Application.Features.Mediator.Results.OrderingResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Application.MappingConfigs;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingQueryHandler(IRepository<Ordering> repository) : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            return ObjectMapper.Mapper.Map<List<GetOrderingQueryResult>>(await repository.GetAllAsync());
        }
    }
}
