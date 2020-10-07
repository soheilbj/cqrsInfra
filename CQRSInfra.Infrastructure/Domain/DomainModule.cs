using Autofac;
using CQRSInfra.Application.Customers.DomainServices;
using CQRSInfra.Domain.Customers;
using CQRSInfra.Domain.ForeignExchange;
using CQRSInfra.Infrastructure.Domain.ForeignExchanges;

namespace CQRSInfra.Infrastructure.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerUniquenessChecker>()
                .As<ICustomerUniquenessChecker>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ForeignExchange>()
                .As<IForeignExchange>()
                .InstancePerLifetimeScope();
        }
    }
}