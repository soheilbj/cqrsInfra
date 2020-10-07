using System;
using  CQRSInfra.Domain.SeedWork;

namespace CQRSInfra.Domain.Products
{
    public class ProductId : TypedIdValueBase
    {
        public ProductId(Guid value) : base(value)
        {
        }
    }
}