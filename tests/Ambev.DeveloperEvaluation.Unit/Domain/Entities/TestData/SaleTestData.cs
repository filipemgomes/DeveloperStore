using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    public static class SaleTestData
    {
        private static readonly Faker Faker = new();

        public static Sale GetValidSale()
        {
            return new Sale(
                Faker.Random.AlphaNumeric(8),
                Faker.Name.FullName(),
                Guid.NewGuid());
        }

        public static Sale GetCancelledSale()
        {
            var sale = new Sale(
                Faker.Random.AlphaNumeric(8),
                Faker.Name.FullName(),
                Guid.NewGuid());
            sale.CancelSale();
            return sale;
        }

        public static List<SaleItem> GetSaleItems()
        {
            return new List<SaleItem>
            {
                new SaleItem(Guid.NewGuid(), null!, Faker.Random.Int(1, 20), Faker.Random.Decimal(5, 50), 0.10m, Faker.Random.Decimal(10, 200)),
                new SaleItem(Guid.NewGuid(), null!, Faker.Random.Int(1, 20), Faker.Random.Decimal(5, 50), 0.20m, Faker.Random.Decimal(10, 200))
            };
        }
    }
}
