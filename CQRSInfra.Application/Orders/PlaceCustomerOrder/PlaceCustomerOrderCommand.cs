using System;
using System.Collections.Generic;
using MediatR;
using CQRSInfra.Application.Configuration.Commands;

namespace CQRSInfra.Application.Orders.PlaceCustomerOrder
{
    public class PlaceCustomerOrderCommand : CommandBase<Guid>
    {
        public Guid CustomerId { get; }

        public List<ProductDto> Products { get; }

        public string Currency { get; }

        public PlaceCustomerOrderCommand(
            Guid customerId, 
            List<ProductDto> products, 
            string currency)
        {
            this.CustomerId = customerId;
            this.Products = products;
            this.Currency = currency;
        }
    }
}