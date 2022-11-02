using Xunit;

namespace Day05_DoesntHeHaveInternElvesForThis.Tests
{
    public class ValidatorTest
    {
        [Theory]
        [InlineData("ugknbfddgicrmopn", true)]
        [InlineData("aaa", true)]
        [InlineData("jchzalrnumimnmhp", false)]
        [InlineData("haegwjzuvuyypxyu", false)]
        [InlineData("dvszwmarrgswjxmb", false)]
        public void SolveOneGivesExpectedOutput(string input, bool expected)
        {
            // Arrange
            var validator = new Validator();

            // Act
            var result = validator.IsNiceLine(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}