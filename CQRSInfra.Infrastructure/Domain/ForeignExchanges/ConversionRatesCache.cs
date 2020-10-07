using System.Collections.Generic;
using CQRSInfra.Domain.ForeignExchange;

namespace CQRSInfra.Infrastructure.Domain.ForeignExchanges
{
    public class ConversionRatesCache
    {
        public List<ConversionRate> Rates { get; }

        public ConversionRatesCache(List<ConversionRate> rates)
        {
            this.Rates = rates;
        }
    }
}