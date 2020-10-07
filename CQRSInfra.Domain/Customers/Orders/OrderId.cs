using System;
using  CQRSInfra.Domain.SeedWork;

namespace CQRSInfra.Domain.Customers.Orders
{
    public class OrderId : TypedIdValueBase
    {
        public OrderId(Guid value) : base(value)
        {
        }
    }
}