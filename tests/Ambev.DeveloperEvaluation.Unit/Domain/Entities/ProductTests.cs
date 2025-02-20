using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class ProductTests
    {
        [Fact]
        public void Product_Should_Be_Created_With_Valid_Data()
        {
            var product = ProductTestData.GenerateValidProduct();

            product.Name.Should().NotBeNullOrEmpty();
            product.UnitPrice.Should().BeGreaterThan(0);
        }

        [Fact]
        public void Product_Should_Not_Allow_Empty_Name()
        {
            var product = new Product("", 10);

            var result = product.Validate();
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeNull().And.NotBeEmpty();
        }

        [Fact]
        public void Product_Should_Not_Allow_Zero_Or_Negative_Price()
        {
            var product = new Product("Valid Product", 0);

            var result = product.Validate();
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeNull().And.NotBeEmpty();
        }
    }
}
