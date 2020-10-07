﻿using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using  CQRSInfra.Domain.Customers.Orders;
using  CQRSInfra.Domain.SeedWork;

namespace CQRSInfra.Domain.Customers.Rules
{
    public class OrderMustHaveAtLeastOneProductRule : IBusinessRule
    {
        private readonly List<OrderProductData> _orderProductData;

        public OrderMustHaveAtLeastOneProductRule(List<OrderProductData> orderProductData)
        {
            _orderProductData = orderProductData;
        }

        public bool IsBroken() => !_orderProductData.Any();

        public string Message => "Order must have at least a product";
    }
}