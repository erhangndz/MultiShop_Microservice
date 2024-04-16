using MediatR;
using Multishop.Order.Application.Features.Mediator.Results.OrderDetailResults;

namespace Multishop.Order.Application.Features.Mediator.Queries.OrderDetailQueries
{
    public class GetOrderDetailQuery : IRequest<List<GetOrderDetailQueryResult>>
    {
    }
}
