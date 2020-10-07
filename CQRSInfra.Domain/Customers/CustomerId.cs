using System;
using  CQRSInfra.Domain.SeedWork;

namespace CQRSInfra.Domain.Customers
{
    public class CustomerId : TypedIdValueBase
    {
        public CustomerId(Guid value) : base(value)
        {
        }
    }
}