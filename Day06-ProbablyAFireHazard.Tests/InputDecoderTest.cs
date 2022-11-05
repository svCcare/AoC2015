namespace Day06_ProbablyAFireHazard.Tests
{
    public class InputDecoderTest
    {
        [Theory]
        [InlineData("turn on 0,0 through 999,999", OperationType.TurnOn, 0, 999, 0, 999)]
        [InlineData("toggle 0,0 through 999,0", OperationType.Toggle, 0, 999, 0, 0)]
        [InlineData("turn off 499,499 through 500,500", OperationType.TurnOff, 499, 500, 499, 500)]
        public void InputDecoderInputTranslationIsCorrect(
            string testInput,
            OperationType expectedOperationType,
            int expectedXFrom, int expectedXTo,
            int expectedYFrom, int expectedYTo)
        {
            // Arrange

            // Act
            var result = InputDecoder.TranslateInput(testInput);

            // Assert
            Assert.Equal(expectedOperationType, result.OperationType);
            Assert.Equal(expectedXFrom, result.XCoordinates.Item1);
            Assert.Equal(expectedXTo, result.XCoordinates.Item2);
            Assert.Equal(expectedYFrom, result.YCoordinates.Item1);
            Assert.Equal(expectedYTo, result.YCoordinates.Item2);
        }
    }
}