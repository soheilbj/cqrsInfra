using System;
using  CQRSInfra.Domain.SeedWork;
using  CQRSInfra.Domain.SharedKernel;

namespace CQRSInfra.Domain.Customers.Orders.Events
{
    public class OrderPlacedEvent : DomainEventBase
    {
        public OrderId OrderId { get; }

        public CustomerId CustomerId { get; }

        public MoneyValue Value { get; }

        public OrderPlacedEvent(
            OrderId orderId, 
            CustomerId customerId, 
            MoneyValue value)
        {
            this.OrderId = orderId;
            this.CustomerId = customerId;
            Value = value;
        }
    }
}