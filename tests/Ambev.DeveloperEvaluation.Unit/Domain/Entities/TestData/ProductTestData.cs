using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    public static class ProductTestData
    {
        private static readonly Faker Faker = new();

        public static Product GenerateValidProduct()
        {
            return new Product(
                Faker.Commerce.ProductName(),
                Faker.Random.Decimal(1, 500)
            );
        }

        public static List<Product> GenerateProductList(int count = 5)
        {
            var products = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                products.Add(GenerateValidProduct());
            }
            return products;
        }
    }
}
