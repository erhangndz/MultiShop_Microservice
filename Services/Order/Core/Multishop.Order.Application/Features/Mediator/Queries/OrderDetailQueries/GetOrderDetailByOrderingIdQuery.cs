using MediatR;
using Multishop.Order.Application.Features.Mediator.Results.OrderDetailResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.Mediator.Queries.OrderDetailQueries
{
    public class GetOrderDetailByOrderingIdQuery(int id):IRequest<List<GetOrderDetailByOrderingIdQueryResult>>
    {
        public int OrderingId { get; set; } = id;
    }
}
