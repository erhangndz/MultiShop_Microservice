using MediatR;
using Multishop.Order.Application.Features.Mediator.Results.OrderDetailResults;

namespace Multishop.Order.Application.Features.Mediator.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery(int id) : IRequest<GetOrderDetailByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
