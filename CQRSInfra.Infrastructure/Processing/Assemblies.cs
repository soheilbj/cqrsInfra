using System.Reflection;
using CQRSInfra.Application.Orders.PlaceCustomerOrder;

namespace CQRSInfra.Infrastructure.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(PlaceCustomerOrderCommand).Assembly;
    }
}