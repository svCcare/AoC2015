using Xunit;

namespace Day02_IWasToldThereWouldBeNoMath.Tests
{
    public class InputDecoderTest
    {
        [Theory]
        [InlineData("2x3x4", new int[3] { 2, 3, 4 })]
        [InlineData("1x1x10", new int[3] { 1, 1, 10 })]
        [InlineData("12x3x6", new int[3] { 3, 6, 12 })]
        public void InputDecoderInputTranslationIsCorrect(string testInput, int[] expected)
        {
            // Arrange

            // Act
            var result = InputDecoder.TranslateInput(testInput);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
