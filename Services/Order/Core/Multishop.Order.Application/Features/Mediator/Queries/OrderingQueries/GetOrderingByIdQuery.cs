using MediatR;
using Multishop.Order.Application.Features.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery(int id) : IRequest<GetOrderingByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
