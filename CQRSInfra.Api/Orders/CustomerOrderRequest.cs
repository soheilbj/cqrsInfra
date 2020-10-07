using System.Collections.Generic;
using CQRSInfra.Application.Orders;

namespace CQRSInfra.API.Orders
{
    public class CustomerOrderRequest
    {
        public List<ProductDto> Products { get; set; }

        public string Currency { get; set; }
    }
}