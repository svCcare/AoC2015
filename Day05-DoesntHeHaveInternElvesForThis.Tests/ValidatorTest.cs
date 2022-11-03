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
            var result = validator.IsNiceLineV1(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("xxyxx", true)]
        [InlineData("aaa", false)]
        [InlineData("susu", true)]
        [InlineData("aaasusu", false)]
        [InlineData("aasusu", true)]
        [InlineData("xssx", false)]
        [InlineData("aaaa", false)]
        [InlineData("xoxoooxx", false)]
        public void SolveTwoGivesExpectedOutput(string input, bool expected)
        {
            // Arrange
            var validator = new Validator();

            // Act
            var result = validator.IsNiceLineV2(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}