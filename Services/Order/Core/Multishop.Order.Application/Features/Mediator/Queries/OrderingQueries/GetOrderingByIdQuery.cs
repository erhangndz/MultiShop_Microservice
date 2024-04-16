using MediatR;
using Multishop.Order.Application.Features.Mediator.Results.OrderingResults;

namespace Multishop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery(int id) : IRequest<GetOrderingByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
