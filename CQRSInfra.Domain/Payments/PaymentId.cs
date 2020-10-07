using System;
using  CQRSInfra.Domain.SeedWork;

namespace CQRSInfra.Domain.Payments
{
    public class PaymentId : TypedIdValueBase
    {
        public PaymentId(Guid value) : base(value)
        {
        }
    }
}