using Xunit;

namespace Day01_NotQuiteLisp.Tests
{
    public class ElevatorLogicTest
    {
        const char CharacterUp = ')';
        const char CharacterDown = '(';

        [Theory]
        [InlineData("(())", CharacterUp, CharacterDown, 0)]
        [InlineData("(()(()(", CharacterUp, CharacterDown, 3)]
        [InlineData("))(((((", CharacterUp, CharacterDown, 3)]
        [InlineData("())", CharacterUp, CharacterDown, -1)]
        [InlineData(")())())", CharacterUp, CharacterDown, -3)]
        public void SolveOneGivesExpectedOutput(string testInput, char characterUp, char characterDown, int expected)
        {
            // Arrange
            var elevatorLogic = new ElevatorLogic(testInput, characterUp, characterDown);

            // Act
            var result = elevatorLogic.SolveOne();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}