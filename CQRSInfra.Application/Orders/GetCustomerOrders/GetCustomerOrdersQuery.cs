using System;
using System.Collections.Generic;
using MediatR;
using CQRSInfra.Application.Configuration.Queries;

namespace CQRSInfra.Application.Orders.GetCustomerOrders
{
    public class GetCustomerOrdersQuery : IQuery<List<OrderDto>>
    {
        public Guid CustomerId { get; }

        public GetCustomerOrdersQuery(Guid customerId)
        {
            this.CustomerId = customerId;
        }
    }
}