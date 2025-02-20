using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleItemTests
    {
        [Fact]
        public void SaleItem_Should_Be_Created_With_Valid_Data()
        {
            var saleItem = SaleItemTestData.GenerateValidSaleItem();

            saleItem.ProductId.Should().NotBeEmpty();
            saleItem.Quantity.Should().BeInRange(1, 20);
            saleItem.UnitPrice.Should().BeGreaterThan(0);
        }

        [Fact]
        public void SaleItem_Should_Calculate_Correct_TotalPrice()
        {
            var saleItem = SaleItemTestData.GenerateValidSaleItem();
            decimal discount = Sale.CalculateDiscount(saleItem.Quantity);
            decimal expectedTotal = saleItem.Quantity * saleItem.UnitPrice * (1 - discount);

            var newSaleItem = new SaleItem(
                saleItem.ProductId,
                null!,
                saleItem.Quantity,
                saleItem.UnitPrice,
                discount,
                expectedTotal
            );

            newSaleItem.TotalPrice.Should().BeApproximately(expectedTotal, 0.01m);
        }

        [Fact]
        public void SaleItem_Should_Not_Allow_More_Than_20_Quantity()
        {
            var saleItem = new SaleItem(
                Guid.NewGuid(),
                null!,
                21,
                10,
                0,
                210
            );

            var result = saleItem.Validate();
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
        }

        [Fact]
        public void SaleItem_Should_Not_Apply_Discount_When_Less_Than_4_Quantity()
        {
            var saleItem = new SaleItem(
                Guid.NewGuid(),
                null!,
                3,
                10,
                0,
                30
            );

            decimal discount = Sale.CalculateDiscount(saleItem.Quantity);
            discount.Should().Be(0);
        }
    }
}
