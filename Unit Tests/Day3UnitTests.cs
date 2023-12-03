﻿using FluentAssertions;
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
        [InlineData("467..114..", '4', '6', '.', '.')]
        [InlineData("...*......", '.', '.', '.', '.')]
        [InlineData("..35..633.", '.', '.', '3', '.')]
        [InlineData("......#...", '.', '.', '.', '.')]
        [InlineData("617*......", '6', '1', '.', '.')]
        [InlineData(".....+.58.", '.', '.', '8', '.')]
        [InlineData("..592.....", '.', '.', '.', '.')]
        [InlineData("......755.", '.', '.', '5', '.')]
        [InlineData("...$.*....", '.', '.', '.', '.')]
        [InlineData(".664.598..", '.', '6', '.', '.')]
        public void Day3_Gear_ParseLine_2DArrayPopulatedSingleLine(string line, char expectedFirst
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


        [Theory]
        [InlineData(5, new string[] { "467.", "...*", "..35", "...." }, '4', '.', '*', '5', '.', '.', '.', '.')]
        public void Day3_Gear_ParseEngineArray_2DArrayPopulate(int dummy, string[] lines, 
            char expFirstLeft, char expFirstRight,
            char expSecondRight, char expThirdRight, char expLastRight,
            char expLastLeft, char expThirdLeft, char expSecondLeft)
        {
            // Arrange

            // Act
            var grid = Day3.Gears.ParseEngineArray(lines);
            var resTopLeft = grid[0, 0];
            var resTopRight = grid[0,grid.GetLength(1)-1];
            var resSecondLeft = grid[1, 0];
            var resSecondRight = grid[1, grid.GetLength(1) - 1];
            var resThirdLeft = grid[2, 0];
            var resThirdRight = grid[2, grid.GetLength(1) - 1];
            var resLastLeft = grid[3, 0];
            var resLastRight = grid[3, grid.GetLength(1) - 1];

            // Assert
            resTopLeft.Should().Be(expFirstLeft);
            resTopLeft.Should().BeOfType(typeof(char));
            resTopRight.Should().Be(expFirstRight);
            resTopRight.Should().BeOfType(typeof(char));

            resSecondLeft.Should().Be(expSecondLeft);
            resSecondLeft.Should().BeOfType(typeof(char));
            resSecondRight.Should().Be(expSecondRight);
            resSecondRight.Should().BeOfType(typeof(char));

            resThirdLeft.Should().Be(expThirdLeft);
            resThirdLeft.Should().BeOfType(typeof(char));
            resThirdRight.Should().Be(expThirdRight);
            resThirdRight.Should().BeOfType(typeof(char));

            resLastLeft.Should().Be(expLastLeft);
            resLastLeft.Should().BeOfType(typeof(char));
            resLastRight.Should().Be(expLastRight);
            resLastRight.Should().BeOfType(typeof(char));
        }


    }
}