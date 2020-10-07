using CQRSInfra.Domain.SeedWork;
using  CQRSInfra.Domain.SeedWork;

namespace CQRSInfra.Domain.Customers
{
    public class CustomerRegisteredEvent : DomainEventBase
    {
        public CustomerId CustomerId { get; }

        public CustomerRegisteredEvent(CustomerId customerId)
        {
            this.CustomerId = customerId;
        }
    }
}