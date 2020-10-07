using NSubstitute;
using NUnit.Framework;
using CQRSInfra.Domain.Customers;
using CQRSInfra.Domain.Customers.Rules;
using CQRSInfra.UnitTests.SeedWork;

namespace CQRSInfra.UnitTests.Customers
{
    [TestFixture]
    public class CustomerRegistrationTests : TestBase
    {
        [Test]
        public void GivenCustomerEmailIsUnique_WhenCustomerIsRegistering_IsSuccessful()
        {
            // Arrange
            var customerUniquenessChecker = Substitute.For<ICustomerUniquenessChecker>();
            const string email = "sbijavar@gmail.com";
            customerUniquenessChecker.IsUnique(email).Returns(true);

            // Act
            var customer = Customer.CreateRegistered(email, "soheil bijavar", customerUniquenessChecker);

            // Assert
            AssertPublishedDomainEvent<CustomerRegisteredEvent>(customer);
        }

        [Test]
        public void GivenCustomerEmailIsNotUnique_WhenCustomerIsRegistering_BreaksCustomerEmailMustBeUniqueRule()
        {            
            var customerUniquenessChecker = Substitute.For<ICustomerUniquenessChecker>();
            const string email = "sbijavar@gmail.com";
            customerUniquenessChecker.IsUnique(email).Returns(false);
            AssertBrokenRule<CustomerEmailMustBeUniqueRule>(() =>
            {
                
                Customer.CreateRegistered(email, "soheil bijavar", customerUniquenessChecker);
            });
        }
    }
}