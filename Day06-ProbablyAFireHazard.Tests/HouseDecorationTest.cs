namespace Day06_ProbablyAFireHazard.Tests
{
    public class HouseDecorationTest
    {
        [Theory]
        [InlineData("toggle 0,0 through 999,999", 2000000)]
        public void LightingUpWorks(string testInput, int expectedBrightness)
        {
            // Arrange
            HouseDecoration houseDecoration = new();
            List<Instruction> instructions = new()
            {
                InputDecoder.TranslateInput(testInput)
            };

            // Act
            houseDecoration.ExecuteInstructions(instructions);

            // Assert
            Assert.Equal(expectedBrightness, houseDecoration.CalculateBrightness());
        }

        [Theory]
        [InlineData(1)]
        public void ExecuteInstructionsResultsInCorrectBrightness(int expectedBrightness)
        {
            // Arrange
            HouseDecoration houseDecoration = new();
            List<Instruction> instructions = new()
            {
                new Instruction("turn on ", (0, 0), (0 , 0))
            };

            // Act
            houseDecoration.ExecuteInstructions(instructions);

            // Assert
            Assert.Equal(expectedBrightness, houseDecoration.CalculateBrightness());
        }

        [Theory]
        [InlineData(0)]
        public void BrightnessCannotBeNegative(int expectedBrightness)
        {
            // Arrange
            HouseDecoration houseDecoration = new();
            List<Instruction> instructions = new()
            {
                new Instruction("turn off ", (0, 0), (0 , 0))
            };

            // Act
            houseDecoration.ExecuteInstructions(instructions);

            // Assert
            Assert.Equal(expectedBrightness, houseDecoration.CalculateBrightness());
        }

        [Theory]
        [InlineData(2)]
        public void ToggleOperationIncreasesBrightnessCorrectly(int expectedBrightness)
        {
            // Arrange
            HouseDecoration houseDecoration = new();
            List<Instruction> instructions = new()
            {
                new Instruction("toggle ", (0, 0), (0 , 0))
            };

            // Act
            houseDecoration.ExecuteInstructions(instructions);

            // Assert
            Assert.Equal(expectedBrightness, houseDecoration.CalculateBrightness());
        }
    }
}