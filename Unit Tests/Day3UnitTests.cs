using Day3;
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
        [InlineData(new string[] { "467.", "...*", "..35", "...." }, '4', '.', '*', '5', '.', '.', '.', '.')]
        public void Day3_Gear_ParseEngineArray_2DArrayPopulate(string[] lines, 
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



        [Theory]
        [InlineData(new string[] { "#67.", "...*", "..35", "...." }, 
            true, true, true, true,
            true, true, true, true,
            false, false, true, true,
            false, false, false, false)]
        public void Day3_Engine_UpdateIncluded_BoolsRepresentAdjacencyToSymbols(string[] lines,
            bool exp00, bool exp01, bool exp02, bool exp03,
            bool exp10, bool exp11, bool exp12, bool exp13,
            bool exp20, bool exp21, bool exp22, bool exp23,
            bool exp30, bool exp31, bool exp32, bool exp33)
        {
            // Arrange
            var grid = Day3.Gears.ParseEngineArray(lines);
            Engine engine = new Engine(grid);
            engine.UpdateIncluded();

            // Act
            var res00 = engine.IsIncluded(0, 0);
            var res01 = engine.IsIncluded(0, 1);
            var res02 = engine.IsIncluded(0, 2);
            var res03 = engine.IsIncluded(0, 3);

            var res10 = engine.IsIncluded(1, 0);
            var res11 = engine.IsIncluded(1, 1);
            var res12 = engine.IsIncluded(1, 2);
            var res13 = engine.IsIncluded(1, 3);

            var res20 = engine.IsIncluded(2, 0);
            var res21 = engine.IsIncluded(2, 1);
            var res22 = engine.IsIncluded(2, 2);
            var res23 = engine.IsIncluded(2, 3);

            var res30 = engine.IsIncluded(3, 0);
            var res31 = engine.IsIncluded(3, 1);
            var res32 = engine.IsIncluded(3, 2);
            var res33 = engine.IsIncluded(3, 3);

            // Assert
            res00.Should().Be(exp00);
            res01.Should().Be(exp01);
            res02.Should().Be(exp02);
            res03.Should().Be(exp03);

            res10.Should().Be(exp10);
            res11.Should().Be(exp11);
            res12.Should().Be(exp12);
            res13.Should().Be(exp13);

            res20.Should().Be(exp20);
            res21.Should().Be(exp21);
            res22.Should().Be(exp22);
            res23.Should().Be(exp23);

            res30.Should().Be(exp30);
            res31.Should().Be(exp31);
            res32.Should().Be(exp32);
            res33.Should().Be(exp33);
        }

        [Theory]
        [InlineData(new string[] { "#67.", "...*", "..35", "...." }, 21)]
        public void Day3_Engine_SumIncluded_ReturnIntSum(string[] lines,
            int expected)
        {
            // Arrange
            var grid = Day3.Gears.ParseEngineArray(lines);
            Engine engine = new Engine(grid);
            engine.UpdateIncluded();


            // Act
            var result = engine.SumIncluded();

            // Assert
            result.Should().Be(expected);
            result.Should().BeOfType(typeof(int));
            result.Should().BeGreaterThanOrEqualTo(0);
        }





    }
}
