using MediatR;
using Multishop.Order.Application.Features.Mediator.Results.AddressResults;

namespace Multishop.Order.Application.Features.Mediator.Queries.AddressQueries
{
    public class GetAddressQuery : IRequest<List<GetAddressQueryResult>>
    {
    }
}
