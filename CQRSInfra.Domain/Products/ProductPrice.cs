using  CQRSInfra.Domain.SharedKernel;

namespace CQRSInfra.Domain.Products
{
    public class ProductPrice
    {
        public MoneyValue Value { get; private set; }

        private ProductPrice()
        {
            
        }
    }
}