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
            var result = Day3.GearRatios.ParseLine(line);
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
            var grid = Day3.GearRatios.ParseEngineArray(lines);
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
            var grid = Day3.GearRatios.ParseEngineArray(lines);
            Engine engine = new Engine(grid);
            engine.UpdateFlags();

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
        [InlineData(new string[] { "467.", "...*", "35..", "...." }, 467)]
        [InlineData(new string[] { "13..", "1*1.", "...7", "..8+" }, 30)]
        public void Day3_Engine_SumIncluded_ReturnIntSum(string[] lines,
            int expected)
        {
            // Arrange
            var grid = Day3.GearRatios.ParseEngineArray(lines);
            Engine engine = new Engine(grid);
            engine.UpdateFlags();


            // Act
            var result = engine.CalcSumIncluded();

            // Assert
            result.Should().Be(expected);
            result.Should().BeOfType(typeof(int));
            result.Should().BeGreaterThanOrEqualTo(0);
        }


        public static IEnumerable<Object[]> Day3_Engine_FindGears_PopulateListOfGears_Data()
        {
            yield return new Object[] { new string[] { "467.", "...*", "35..", "...." }, 
                new List<Gear> {new Gear(1, 3) } };
            yield return new Object[] { new string[] { "13..", "1*1.", "...7", "..8*" },
                new List<Gear> {new Gear(1, 1), new Gear(3, 3) } };
        }
        [Theory]
        [MemberData(nameof(Day3_Gear_FindGears_PopulateListOfGears_Data))]
        public void Day3_Engine_FindGears_PopulateListOfGears(string[] lines,
            List<Gear> expectedGears)
        {
            // Arrange
            var grid = Day3.GearRatios.ParseEngineArray(lines);
            Engine engine = new Engine(grid);



            // Act
            engine.FindGears();
            List<Gear> gearsResult = engine.gears;
            // Assert
            
            gearsResult.Count.Should().Be(expectedGears.Count);
            for (int i = 0; i < expectedGears.Count; i++)
            {
                gearsResult[i].row.Should().Be(expectedGears[i].row);
                gearsResult[i].col.Should().Be(expectedGears[i].col);
            }
        }

        [Theory]
        [InlineData(new string[] { "_6*.", "...*", "..35", "...." },
            false, true, true, true,
            false, true, true, true,
            false, false, true, true,
            false, false, false, false)]
        public void Day3_Engine_UpdateFlags_BoolsRepresentAdjacencyToGears(string[] lines,
            bool exp00, bool exp01, bool exp02, bool exp03,
            bool exp10, bool exp11, bool exp12, bool exp13,
            bool exp20, bool exp21, bool exp22, bool exp23,
            bool exp30, bool exp31, bool exp32, bool exp33)
        {
            // Arrange
            var grid = Day3.GearRatios.ParseEngineArray(lines);
            Engine engine = new Engine(grid);
            engine.UpdateFlags();

            // Act
            var res00 = engine.IsAdjacentToGear(0, 0);
            var res01 = engine.IsAdjacentToGear(0, 1);
            var res02 = engine.IsAdjacentToGear(0, 2);
            var res03 = engine.IsAdjacentToGear(0, 3);

            var res10 = engine.IsAdjacentToGear(1, 0);
            var res11 = engine.IsAdjacentToGear(1, 1);
            var res12 = engine.IsAdjacentToGear(1, 2);
            var res13 = engine.IsAdjacentToGear(1, 3);

            var res20 = engine.IsAdjacentToGear(2, 0);
            var res21 = engine.IsAdjacentToGear(2, 1);
            var res22 = engine.IsAdjacentToGear(2, 2);
            var res23 = engine.IsAdjacentToGear(2, 3);

            var res30 = engine.IsAdjacentToGear(3, 0);
            var res31 = engine.IsAdjacentToGear(3, 1);
            var res32 = engine.IsAdjacentToGear(3, 2);
            var res33 = engine.IsAdjacentToGear(3, 3);

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



        public static IEnumerable<Object[]> Day3_Gear_FindGears_PopulateListOfGears_Data()
        {
            yield return new Object[] { new string[] { "467.", "...*", "35..", "...." },
                new List<Gear> {new Gear(1, 3, new List<int> { 467 }) } };
            yield return new Object[] { new string[] { "13..", "1*1.", "...7", "..8*" },
                new List<Gear> {new Gear(1, 1, new List<int> { 13, 1, 1 }) ,
                new Gear(3, 3, new List<int> { 7, 8 }) }};
            yield return new Object[] { new string[] { "*1.", "2..", "3*4" },
                new List<Gear> {new Gear(0, 0, new List<int> { 1, 2 }) ,
                new Gear(2, 1, new List<int> { 2, 3, 4 }) }};
        }
        [Theory]
        [MemberData(nameof(Day3_Gear_FindGears_PopulateListOfGears_Data))]
        public void Day3_Engine_CalcGearAdjacentNumbers_PopulateListOfAdjacentNums(string[] lines,
            List<Gear> expectedGears)
        {
            // Arrange
            var grid = Day3.GearRatios.ParseEngineArray(lines);
            Engine engine = new Engine(grid);



            // Act
            engine.FindGears();
            engine.CalcGearAdjacentNumbers();
            
            List<Gear> resultGears = engine.gears;

            // Assert
            resultGears.Count.Should().Be(expectedGears.Count);
            for (int i = 0; i < expectedGears.Count; i++)
            {
                // Should be same number of gears in each Engine
                resultGears[i].adjacentNumbers.Count.Should().Be(expectedGears[i].adjacentNumbers.Count);
                for (int j = 0; j < resultGears[i].adjacentNumbers.Count; j++)
                {
                    // Each number should be equal
                    resultGears[i].adjacentNumbers[j].Should().Be(expectedGears[i].adjacentNumbers[j]);
                }
            }
        }
    }
}
