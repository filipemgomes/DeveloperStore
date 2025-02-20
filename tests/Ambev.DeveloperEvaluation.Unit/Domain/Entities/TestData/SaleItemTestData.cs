using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    public static class SaleItemTestData
    {
        private static readonly Faker Faker = new();

        public static SaleItem GenerateValidSaleItem()
        {
            return new SaleItem(
                Guid.NewGuid(),
                null!, 
                Faker.Random.Int(1, 20),
                Faker.Random.Decimal(5, 100),
                0,
                0
            );
        }

        public static List<SaleItem> GenerateSaleItemList(int count = 5)
        {
            var items = new List<SaleItem>();
            for (int i = 0; i < count; i++)
            {
                var item = GenerateValidSaleItem();
                decimal discount = Sale.CalculateDiscount(item.Quantity);
                item = new SaleItem(
                    item.ProductId,
                    null!,
                    item.Quantity,
                    item.UnitPrice,
                    discount,
                    item.Quantity * item.UnitPrice * (1 - discount)
                );
                items.Add(item);
            }
            return items;
        }
    }
}
