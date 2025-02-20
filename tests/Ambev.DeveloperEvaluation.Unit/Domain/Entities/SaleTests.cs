using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Bogus;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        private readonly Faker _faker = new();

        [Fact]
        public void Sale_Should_Be_Created_With_Valid_Data()
        {
            var sale = SaleTestData.GetValidSale();

            sale.SaleNumber.Should().NotBeNullOrEmpty();
            sale.Customer.Should().NotBeNullOrEmpty();
            sale.BranchId.Should().NotBeEmpty();
            sale.Status.Should().Be(SaleStatusEnum.Active);
            sale.TotalAmount.Should().Be(0);
            sale.SaleItems.Should().BeEmpty();
        }

        [Fact]
        public void Sale_Should_Be_Cancelled()
        {
            var sale = SaleTestData.GetValidSale();
            sale.CancelSale();
            sale.Status.Should().Be(SaleStatusEnum.Cancelled);
        }

        [Fact]
        public void Sale_Should_Be_Updated()
        {
            var sale = SaleTestData.GetValidSale();
            var newCustomer = _faker.Name.FullName();
            var newBranchId = Guid.NewGuid();

            sale.UpdateSale(newCustomer, newBranchId);

            sale.Customer.Should().Be(newCustomer);
            sale.BranchId.Should().Be(newBranchId);
        }

        [Fact]
        public void SaleItems_Should_Be_Updated_And_Total_Calculated()
        {
            var sale = SaleTestData.GetValidSale();
            var saleItems = SaleTestData.GetSaleItems();

            sale.UpdateSaleItems(saleItems);

            sale.SaleItems.Should().BeEquivalentTo(saleItems);
            sale.TotalAmount.Should().Be(saleItems.Sum(item => item.TotalPrice));
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(4, 0.10)]
        [InlineData(9, 0.10)]
        [InlineData(10, 0.20)]
        [InlineData(20, 0.20)]
        [InlineData(21, 0)]
        public void Sale_Should_Calculate_Correct_Discount(int quantity, decimal expectedDiscount)
        {
            var discount = Sale.CalculateDiscount(quantity);
            discount.Should().Be(expectedDiscount);
        }

        [Fact]
        public void Sale_Should_Not_Allow_More_Than_20_Items_Per_Product()
        {
            var sale = SaleTestData.GetValidSale();
            var saleItems = new List<SaleItem>
            {
                new SaleItem(Guid.NewGuid(), null!, 21, 10, 0, 210)
            };

            var act = () => sale.UpdateSaleItems(saleItems);
            var result = sale.Validate();
            result.IsValid.Should().BeFalse();
            result.Errors.Should().NotBeEmpty();
        }
    }
}
