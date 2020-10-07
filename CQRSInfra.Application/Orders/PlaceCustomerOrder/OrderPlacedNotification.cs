using Newtonsoft.Json;
using CQRSInfra.Application.Configuration.DomainEvents;
using CQRSInfra.Domain.Customers;
using CQRSInfra.Domain.Customers.Orders;
using CQRSInfra.Domain.Customers.Orders.Events;

namespace CQRSInfra.Application.Orders.PlaceCustomerOrder
{
    public class OrderPlacedNotification : DomainNotificationBase<OrderPlacedEvent>
    {
        public OrderId OrderId { get; }
        public CustomerId CustomerId { get; }

        public OrderPlacedNotification(OrderPlacedEvent domainEvent) : base(domainEvent)
        {
            this.OrderId = domainEvent.OrderId;
            this.CustomerId = domainEvent.CustomerId;
        }

        [JsonConstructor]
        public OrderPlacedNotification(OrderId orderId, CustomerId customerId) : base(null)
        {
            this.OrderId = orderId;
            this.CustomerId = customerId;
        }
    }
}