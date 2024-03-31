﻿using MediatR;
using Multishop.Order.Application.Features.Mediator.Results.OrderDetailResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Order.Application.Features.Mediator.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery(int id): IRequest<GetOrderDetailByIdQueryResult>
    {
        public int Id { get; set; } = id;
    }
}
