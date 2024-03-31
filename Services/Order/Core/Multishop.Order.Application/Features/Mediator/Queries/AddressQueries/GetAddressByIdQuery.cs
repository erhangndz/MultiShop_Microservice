using MediatR;
using Multishop.Order.Application.Features.Mediator.Results.AddressResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.Mediator.Queries.AddressQueries
{
    public class GetAddressByIdQuery(int id): IRequest<GetAddressByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
