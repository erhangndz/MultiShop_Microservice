using MediatR;
using Multishop.Order.Application.Features.Mediator.Results.OrderingResults;

namespace Multishop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
    {
    }
}
