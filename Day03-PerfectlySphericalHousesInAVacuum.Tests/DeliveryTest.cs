using Xunit;

namespace Day03_PerfectlySphericalHousesInAVacuum.Tests
{
    public class DeliveryTest
    {
        [Theory]
        [InlineData(">", 2)]
        [InlineData("^>v<", 4)]
        [InlineData("^v^v^v^v^v", 2)]
        public void SolveOneGivesExpectedOutput(string testInput, int expected)
        {
            // Arrange
            var delivery = new SantaDelivery(testInput);

            // Act
            delivery.BeginDelivery();

            // Assert
            Assert.Equal(expected, delivery.GetAddressCheckListCount());
        }

        [Theory]
        [InlineData("^v", 3)]
        [InlineData("^>v<", 3)]
        [InlineData("^v^v^v^v^v", 11)]
        public void SolveTwoGivesExpectedOutput(string testInput, int expected)
        {
            // Arrange
            var delivery = new SantaBotDelivery(testInput);

            // Act
            delivery.BeginDelivery();

            // Assert
            Assert.Equal(expected, delivery.GetAddressCheckListCount());
        }
    }
}