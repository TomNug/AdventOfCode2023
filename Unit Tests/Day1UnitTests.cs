using FluentAssertions;

namespace Unit_Tests
{
    public class Day1UnitTests
    {
        [Theory]
        [InlineData("1abc2", 12)]
        [InlineData("pqr3stu8vwx", 38)]
        [InlineData("a1b2c3d4e5f", 15)]
        [InlineData("treb7uchet", 77)]
        public void Day1_Trebuchet_ExtractNumber_ReturnFirstLastInt(string input, int expected)
        {
            // Arrange

            // Act
            var result = Day1.Trebuchet.ExtractNumber(input);
            // Assert
            result.Should().Be(expected);
            result.Should().BeOfType(typeof(int));
        }

        [Theory]
        [InlineData("two1nine", 29)]
        [InlineData("eightwothree", 83)]
        [InlineData("abcone2threexyz", 13)]
        [InlineData("xtwone3four", 24)]
        [InlineData("4nineeightseven2", 42)]
        [InlineData("zoneight234", 14)]
        [InlineData("7pqrstsixteen", 76)]
        public void Day1_Trebuchet_ExtractNumberWords_ReturnFirstLastInt(string input, int expected)
        {
            // Arrange

            // Act
            var result = Day1.Trebuchet.ExtractNumberWords(input);
            // Assert
            result.Should().Be(expected);
            result.Should().BeOfType(typeof(int));
        }


    }
}