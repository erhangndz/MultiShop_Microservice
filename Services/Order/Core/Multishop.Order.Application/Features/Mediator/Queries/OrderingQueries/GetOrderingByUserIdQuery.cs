using MediatR;
using Multishop.Order.Application.Features.Mediator.Results.OrderingResults;

namespace Multishop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByUserIdQuery(string id): IRequest<List<GetOrderingByUserIdQueryResult>>
    {
        public string UserId { get; set; } = id;

    }
}
