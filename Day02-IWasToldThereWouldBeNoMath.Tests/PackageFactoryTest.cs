using Xunit;

namespace Day02_IWasToldThereWouldBeNoMath.Tests
{
    public class PackageFactoryTest
    {
        [Theory]
        [InlineData(new string[1] { "2x3x4" }, 1)]
        [InlineData(new string[3] { "2x3x4", "2x3x4", "2x3x4" }, 3)]
        public void PackageFactoryCreatesCorrectNumberOfPackages(string[] testInput, int expected)
        {
            // Arrange & Act
            PackageFactory packageFactory = new(testInput);

            // Assert
            Assert.Equal(expected, packageFactory.Packages.Count);
        }
    }
}