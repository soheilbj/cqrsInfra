using  CQRSInfra.Domain.SeedWork;
using  CQRSInfra.Domain.SharedKernel;

namespace CQRSInfra.Domain.Products
{
    public class ProductPriceData : ValueObject
    {
        public ProductPriceData(ProductId productId, MoneyValue price)
        {
            ProductId = productId;
            Price = price;
        }

        public ProductId ProductId { get; }

        public MoneyValue Price { get; }
    }
}