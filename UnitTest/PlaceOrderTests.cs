﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using CQRSInfra.Domain.Customers.Orders;
using CQRSInfra.Domain.Customers.Orders.Events;
using CQRSInfra.Domain.Customers.Rules;
using CQRSInfra.Domain.ForeignExchange;
using CQRSInfra.Domain.Products;
using CQRSInfra.Domain.SharedKernel;
using CQRSInfra.UnitTests.SeedWork;
using CQRSInfra.UnitTests.Customers;

namespace UnitTests.Customers
{
    [TestFixture]
    public class PlaceOrderTests : TestBase
    {
        [Test]
        public void PlaceOrder_WhenAtLeastOneProductIsAdded_IsSuccessful()
        {
            // Arrange
            var customer = CustomerFactory.Create();

            var orderProductsData = new List<OrderProductData>();
            orderProductsData.Add(new OrderProductData(SampleProducts.Product1Id, 2));
            
            var allProductPrices = new List<ProductPriceData>
            {
                SampleProductPrices.Product1EUR, SampleProductPrices.Product1USD
            };
            
            const string currency = "Rial";
            var conversionRates = GetConversionRates();
            
            // Act
            customer.PlaceOrder(
                orderProductsData, 
                allProductPrices, 
                currency, 
                conversionRates);

            // Assert
            var orderPlaced = AssertPublishedDomainEvent<OrderPlacedEvent>(customer);
            Assert.That(orderPlaced.Value, Is.EqualTo(MoneyValue.Of(200, "Rial")));
        }

        [Test]
        public void PlaceOrder_WhenNoProductIsAdded_BreaksOrderMustHaveAtLeastOneProductRule()
        {
            // Arrange
            var customer = CustomerFactory.Create();

            var orderProductsData = new List<OrderProductData>();

            var allProductPrices = new List<ProductPriceData>
            {
                SampleProductPrices.Product1EUR, SampleProductPrices.Product1USD
            };

            const string currency = "Rial";
            var conversionRates = GetConversionRates();

            // Assert
            AssertBrokenRule<OrderMustHaveAtLeastOneProductRule>(() =>
            {
                // Act
                customer.PlaceOrder(
                    orderProductsData,
                    allProductPrices,
                    currency,
                    conversionRates);
            });
        }

        [Test]
        public void PlaceOrder_GivenTwoOrdersInThatDayAlreadyMade_BreaksCustomerCannotOrderMoreThan2OrdersOnTheSameDayRule()
        {
            // Arrange
            var customer = CustomerFactory.Create();

            var orderProductsData = new List<OrderProductData>();
            orderProductsData.Add(new OrderProductData(SampleProducts.Product1Id, 2));

            var allProductPrices = new List<ProductPriceData>
            {
                SampleProductPrices.Product1EUR, SampleProductPrices.Product1USD
            };

            const string currency = "Rial";
            var conversionRates = GetConversionRates();

            SystemClock.Set(new DateTime(2020, 1, 10, 11, 0, 0));
            customer.PlaceOrder(
                orderProductsData,
                allProductPrices,
                currency,
                conversionRates);

            SystemClock.Set(new DateTime(2020, 1, 10, 11, 30, 0));
            customer.PlaceOrder(
                orderProductsData,
                allProductPrices,
                currency,
                conversionRates);

            SystemClock.Set(new DateTime(2020, 1, 10, 12, 00, 0));

            // Assert
            AssertBrokenRule<CustomerCannotOrderMoreThan2OrdersOnTheSameDayRule>(() =>
            {
                // Act
                customer.PlaceOrder(
                    orderProductsData,
                    allProductPrices,
                    currency,
                    conversionRates);
            });
        }

        private static List<ConversionRate> GetConversionRates()
        {

            var conversionRates = new List<ConversionRate>();

            conversionRates.Add(new ConversionRate("USD", "Rial", (decimal)0.88));
            conversionRates.Add(new ConversionRate("Rial", "USD", (decimal)1.13));

            return conversionRates;
        }
    }



    public class SampleProducts
    {
        public static readonly ProductId Product1Id = new ProductId(Guid.NewGuid());

        public static readonly ProductId Product2Id = new ProductId(Guid.NewGuid());
    }

    public class SampleProductPrices
    {
        public static readonly ProductPriceData Product1EUR = new ProductPriceData(SampleProducts.Product1Id,MoneyValue.Of(30000000, "Rial"));

        public static readonly ProductPriceData Product1USD = new ProductPriceData(SampleProducts.Product1Id,MoneyValue.Of(100, "USD"));
    }
}