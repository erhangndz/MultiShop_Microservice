using MediatR;
using Multishop.Order.Application.Features.Mediator.Queries.AddressQueries;
using Multishop.Order.Application.Features.Mediator.Results.AddressResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Application.MappingConfigs;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler(IRepository<Address> repository) : IRequestHandler<GetAddressQuery, List<GetAddressQueryResult>>
    {
        public async Task<List<GetAddressQueryResult>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {

            return ObjectMapper.Mapper.Map<List<GetAddressQueryResult>>(await repository.GetAllAsync());
        }
    }
}
