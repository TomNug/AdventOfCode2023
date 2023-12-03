using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests
{
    public class Day3UnitTests
    {
        [Theory]
        [InlineData("467..114..", '4', '6', '.','.')]
        [InlineData("...*......", '.', '.', '.', '.')]
        [InlineData("..35..633.", '.', '.', '3', '.')]
        [InlineData("......#...", '.', '.', '.', '.')]
        [InlineData("617*......", '6', '1', '.', '.')]
        [InlineData(".....+.58.", '.', '.', '5', '8')]
        [InlineData("..592.....", '.', '.', '.', '.')]
        [InlineData("......755.", '.', '.', '5', '.')]
        [InlineData("...$.*....", '.', '.', '.', '.')]
        [InlineData(".664.598..", '.', '6', '.', '.')]
        public void Day3_Gear_ParseEngineArray_2DArrayPopulatedSingleLine(string line, char expectedFirst
            , char expectedSecond, char expectedPenultimate, char expectedLast)
        {
            // Arrange
            // Act
            var result = Day3.Gears.ParseLine(line);
            var first = result[0];
            var second = result[1];
            var penultimate = result[result.Length - 2];
            var last = result[result.Length - 1];
            // Assert
            first.Should().Be(expectedFirst);
            first.Should().BeOfType(typeof(char));

            second.Should().Be(expectedSecond);
            second.Should().BeOfType(typeof(char));

            penultimate.Should().Be(expectedPenultimate);
            penultimate.Should().BeOfType(typeof(char));

            last.Should().Be(expectedLast);
            last.Should().BeOfType(typeof(char));
        }
    }
}
