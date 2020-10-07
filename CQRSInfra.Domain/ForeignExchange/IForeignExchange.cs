using System.Collections.Generic;

namespace CQRSInfra.Domain.ForeignExchange
{
    public interface IForeignExchange
    {
        List<ConversionRate> GetConversionRates();
    }
}