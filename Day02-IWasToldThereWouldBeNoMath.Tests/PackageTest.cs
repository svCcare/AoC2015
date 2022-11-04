using Xunit;

namespace Day02_IWasToldThereWouldBeNoMath.Tests
{
    public class PackageTest
    {
        [Theory]
        [InlineData(2, 3, 4, 58)]
        [InlineData(1, 1, 10, 43)]
        public void PackagePaperNeededIsCorrect(int a, int b, int c, int expected)
        {
            // Arrange & Act
            Package package = new(a, b, c);

            // Assert
            Assert.Equal(expected, package.PaperNeeded);
        }

        [Theory]
        [InlineData(2, 3, 4, 34)]
        [InlineData(1, 1, 10, 14)]
        public void PackageRibbonNeededIsCorrect(int a, int b, int c, int expected)
        {
            // Arrange & Act
            Package package = new(a, b, c);

            // Assert
            Assert.Equal(expected, package.RibbonNeeded);
        }
    }
}