using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    public static class BranchTestData
    {
        private static readonly Faker Faker = new();

        public static Branch GenerateValidBranch()
        {
            return new Branch(
                Faker.Company.CompanyName(),
                Faker.Address.FullAddress(),
                Faker.Random.Bool()
            );
        }

        public static List<Branch> GenerateBranchList(int count = 5)
        {
            var branches = new List<Branch>();
            for (int i = 0; i < count; i++)
            {
                branches.Add(GenerateValidBranch());
            }
            return branches;
        }
    }
}
