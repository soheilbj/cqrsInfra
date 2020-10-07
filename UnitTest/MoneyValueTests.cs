using System.Collections.Generic;
using NUnit.Framework;
using CQRSInfra.Domain.SharedKernel;
using CQRSInfra.UnitTests.SeedWork;

namespace CQRSInfra.UnitTests.SharedKernel
{
    [TestFixture]
    public class MoneyValueTests : TestBase
    {
        [Test]
        public void MoneyValueOf_WhenCurrencyIsProvided_IsSuccessful()
        {
            var value = MoneyValue.Of(120, "Rial");

            Assert.That(value.Value, Is.EqualTo(120));
            Assert.That(value.Currency, Is.EqualTo("Rial"));
        }

        [Test]
        public void MoneyValueOf_WhenCurrencyIsNotProvided_ThrowsMoneyValueMustHaveCurrencyRuleBroken()
        {
            AssertBrokenRule<MoneyValueMustHaveCurrencyRule>(() =>
            {
                MoneyValue.Of(120, "");
            });
        }

        [Test]
        public void GivenTwoMoneyValuesWithTheSameCurrencies_WhenAddThem_IsSuccessful()
        {
            var valueInEuros = MoneyValue.Of(100, "Rial");
            var valueInEuros2 = MoneyValue.Of(50, "Rial");

            MoneyValue add = valueInEuros + valueInEuros2;

            Assert.That(add.Value, Is.EqualTo(150));
            Assert.That(add.Currency, Is.EqualTo("Rial"));
        }

        [Test]
        public void GivenTwoMoneyValuesWithTheSameCurrencies_SumThem_IsSuccessful()
        {
            var valueInEuros = MoneyValue.Of(100, "Rial");
            var valueInEuros2 = MoneyValue.Of(50, "Rial");

            IList<MoneyValue> values = new List<MoneyValue>
            {
                valueInEuros, valueInEuros2
            };

            MoneyValue add = values.Sum();

            Assert.That(add.Value, Is.EqualTo(150));
            Assert.That(add.Currency, Is.EqualTo("Rial"));
        }

        [Test]
        public void GivenTwoMoneyValuesWithDifferentCurrencies_WhenAddThem_ThrowsMoneyValueOperationMustBePerformedOnTheSameCurrencyRule()
        {
            var valueInEuros = MoneyValue.Of(100, "Rial");
            var valueInDollars = MoneyValue.Of(50, "USD");
            AssertBrokenRule<MoneyValueOperationMustBePerformedOnTheSameCurrencyRule>(() =>
            {
                var add = valueInEuros + valueInDollars;
            });
        }
    }
}