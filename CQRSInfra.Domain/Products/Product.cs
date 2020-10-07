using System;
using System.Collections.Generic;
using System.Linq;
using  CQRSInfra.Domain.SeedWork;
using  CQRSInfra.Domain.SharedKernel;

namespace CQRSInfra.Domain.Products
{
    public class Product : Entity, IAggregateRoot
    {
        public ProductId Id { get; private set; }

        public string Name { get; private set; }

        private List<ProductPrice> _prices;

        private Product()
        {

        }
    }
}