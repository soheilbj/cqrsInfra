using System.Data.SqlClient;
using System.Threading.Tasks;
using NUnit.Framework;
using CQRSInfra.Application.Customers.GetCustomerDetails;
using CQRSInfra.Application.Customers.IntegrationHandlers;
using CQRSInfra.Application.Customers.RegisterCustomer;
using CQRSInfra.Domain.Customers;
using CQRSInfra.Infrastructure.Processing;
using CQRSInfra.IntegrationTests.SeedWork;

namespace CQRSInfra.IntegrationTests.Customers
{
    [TestFixture]
    public class CustomersTests : TestBase
    {
        [Test]
        public async Task RegisterCustomerTest()
        {
            const string email = "sbijavar@gmail.com";
            const string name = "soheil bijavar company";
            
            var customer = await CommandsExecutor.Execute(new RegisterCustomerCommand(email, name));
            var customerDetails = await QueriesExecutor.Execute(new GetCustomerDetailsQuery(customer.Id));

            Assert.That(customerDetails, Is.Not.Null);
            Assert.That(customerDetails.Name, Is.EqualTo(name));
            Assert.That(customerDetails.Email, Is.EqualTo(email));

            var connection = new SqlConnection(ConnectionString);
            var messagesList = await OutboxMessagesHelper.GetOutboxMessages(connection);

            Assert.That(messagesList.Count, Is.EqualTo(1));

            var customerRegisteredNotification =
                OutboxMessagesHelper.Deserialize<CustomerRegisteredNotification>(messagesList[0]);

            Assert.That(customerRegisteredNotification.CustomerId, Is.EqualTo(new CustomerId(customer.Id)));
        }
    }
}