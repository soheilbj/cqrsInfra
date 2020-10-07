using System;
using  CQRSInfra.Domain.Customers.Orders;
using  CQRSInfra.Domain.SeedWork;

namespace CQRSInfra.Domain.Payments
{
    public class PaymentCreatedEvent : DomainEventBase
    {
        public PaymentCreatedEvent(PaymentId paymentId, OrderId orderId)
        {
            this.PaymentId = paymentId;
            this.OrderId = orderId;
        }

        public PaymentId PaymentId { get; }

        public OrderId OrderId { get; }
    }
}