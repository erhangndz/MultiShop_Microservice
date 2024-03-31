using MediatR;
using Multishop.Order.Application.Features.Mediator.Queries.AddressQueries;
using Multishop.Order.Application.Features.Mediator.Results.AddressResults;
using Multishop.Order.Application.Interfaces;
using Multishop.Order.Application.MappingConfigs;
using Multishop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.Mediator.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler(IRepository<Address> repository) : IRequestHandler<GetAddressQuery, List<GetAddressQueryResult>>
    {
        public async Task<List<GetAddressQueryResult>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
        {
            var values =  await repository.GetAllAsync();
            return ObjectMapper.Mapper.Map<List<GetAddressQueryResult>>(values);
        }
    }
}
