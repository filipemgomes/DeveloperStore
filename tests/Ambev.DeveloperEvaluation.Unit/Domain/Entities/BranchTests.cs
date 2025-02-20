using System;
using Xunit;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Tests.Domain
{
    public class BranchTests
    {
        [Fact]
        public void Should_Create_Branch_With_Valid_Parameters()
        {
            // Arrange
            var branch = BranchTestData.GenerateValidBranch();

            // Assert
            Assert.NotNull(branch);
            Assert.False(string.IsNullOrEmpty(branch.Name));
            Assert.False(string.IsNullOrEmpty(branch.Location));
        }

        [Fact]
        public void Should_Not_Create_Branch_With_Empty_Name()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new Branch(string.Empty, "123 Main St, City, Country", true));
        }

        [Fact]
        public void Should_Not_Create_Branch_With_Empty_Location()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => new Branch("Central Branch", string.Empty, true));
        }

        [Fact]
        public void Should_Generate_List_Of_Valid_Branches()
        {
            // Arrange
            var branches = BranchTestData.GenerateBranchList(5);

            // Assert
            Assert.NotNull(branches);
            Assert.Equal(5, branches.Count);
            Assert.All(branches, branch =>
            {
                Assert.False(string.IsNullOrEmpty(branch.Name));
                Assert.False(string.IsNullOrEmpty(branch.Location));
            });
        }
    }
}
