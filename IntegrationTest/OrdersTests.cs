using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using NUnit.Framework;
using CQRSInfra.Application.Customers.IntegrationHandlers;
using CQRSInfra.Application.Customers.RegisterCustomer;
using CQRSInfra.Application.Orders;
using CQRSInfra.Application.Orders.GetCustomerOrderDetails;
using CQRSInfra.Application.Orders.PlaceCustomerOrder;
using CQRSInfra.Application.Payments;
using CQRSInfra.Domain.Customers;
using CQRSInfra.Domain.Customers.Orders;
using CQRSInfra.Infrastructure.Processing;
using CQRSInfra.IntegrationTests.SeedWork;

namespace CQRSInfra.IntegrationTests.Orders
{
    [TestFixture]
    public class OrdersTests : TestBase
    {
        [Test]
        public async Task PlaceOrder_Test()
        {
            var customerEmail = "sbijavar@gmail.com";
            var customer = await CommandsExecutor.Execute(new RegisterCustomerCommand(customerEmail, "soheil bijavar"));

            List<ProductDto> products = new List<ProductDto>();
            var productId = Guid.Parse("cdd19ddd-647a-4af7-9f95-cfef9e346c40");
            products.Add(new ProductDto(productId, 2));
            var orderId = await CommandsExecutor.Execute(new PlaceCustomerOrderCommand(customer.Id, products, "Rial"));

            var orderDetails = await QueriesExecutor.Execute(new GetCustomerOrderDetailsQuery(orderId));

            Assert.That(orderDetails, Is.Not.Null);
            Assert.That(orderDetails.Value, Is.EqualTo(80));
            Assert.That(orderDetails.Products.Count, Is.EqualTo(1));
            Assert.That(orderDetails.Products[0].Quantity, Is.EqualTo(2));
            Assert.That(orderDetails.Products[0].Id, Is.EqualTo(productId));

            var connection = new SqlConnection(ConnectionString);
            var messagesList = await OutboxMessagesHelper.GetOutboxMessages(connection);
            
            Assert.That(messagesList.Count, Is.EqualTo(3));
            
            var customerRegisteredNotification =
                OutboxMessagesHelper.Deserialize<CustomerRegisteredNotification>(messagesList[0]);

            Assert.That(customerRegisteredNotification.CustomerId, Is.EqualTo(new CustomerId(customer.Id)));

            var orderPlaced =
                OutboxMessagesHelper.Deserialize<OrderPlacedNotification>(messagesList[1]);

            Assert.That(orderPlaced.OrderId, Is.EqualTo(new OrderId(orderId)));

            var paymentCreated =
                OutboxMessagesHelper.Deserialize<PaymentCreatedNotification>(messagesList[2]);

            Assert.That(paymentCreated, Is.Not.Null);
        }
    }
}