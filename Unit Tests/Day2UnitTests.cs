using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests
{
    public class Day2UnitTests
    {
        [Theory]
        [InlineData(1, 2, 3, 1, 2, 3)]
        [InlineData(0, 0, 0, 0,0, 0)]
        [InlineData(10, 10, 10, 10, 10, 10)]
        public void Day2_Cube_Cube_MaxRGBSet(int redStart, int greenStart, int blueStart, int expectedRed, int expectedGreen, int expectedBlue)
        {
            // Arrange
            var cube = new Day2.Game(1, redStart, greenStart, blueStart);
            // Act
            var resultR = cube.MaxR;
            var resultG = cube.MaxG;
            var resultB = cube.MaxB;
            // Assert
            resultR.Should().Be(expectedRed);
            resultR.Should().BeOfType(typeof(int));
            resultR.Should().BeGreaterThanOrEqualTo(0);

            resultG.Should().Be(expectedGreen);
            resultG.Should().BeOfType(typeof(int));
            resultG.Should().BeGreaterThanOrEqualTo(0);

            resultB.Should().Be(expectedBlue);
            resultB.Should().BeOfType(typeof(int));
            resultB.Should().BeGreaterThanOrEqualTo(0);

        }

        [Theory]
        [InlineData(1, 2, 3, 2, 3, 4, 2, 3, 4)]
        [InlineData(0,0,0,1,1,1,1,1,1)]
        [InlineData(0,0,0,1,0,0,1,0,0)]
        [InlineData(0,0,0,0,1,0,0,1,0)]
        [InlineData(0,0,0,0,0,1,0,0,1)]
        public void Day2_Cube_AddCubeDraw_MaxRGBIncreases(int rStart, int gStart, int bStart, int rAdd, int gAdd, int bAdd, int rExp, int gExp, int bExp)
        {
            // Arrange
            var cube = new Day2.Game(1, rStart, gStart, bStart);
            // Act
            cube.AddCubeDraw(rAdd, gAdd, bAdd);
            var resultR = cube.MaxR;
            var resultG = cube.MaxG;
            var resultB = cube.MaxB;
            // Assert
            resultR.Should().Be(rExp);
            resultR.Should().BeOfType(typeof(int));
            resultR.Should().BeGreaterThanOrEqualTo(0);
            resultR.Should().BeGreaterThanOrEqualTo(rStart);
            resultG.Should().Be(gExp);
            resultG.Should().BeOfType(typeof(int));
            resultG.Should().BeGreaterThanOrEqualTo(0);
            resultG.Should().BeGreaterThanOrEqualTo(gStart);
            resultB.Should().Be(bExp);
            resultB.Should().BeOfType(typeof(int));
            resultB.Should().BeGreaterThanOrEqualTo(0);
            resultB.Should().BeGreaterThanOrEqualTo(bStart);
        }

        [Theory]
        [InlineData(1, 1, 1, 0, 0, 0, 1, 1, 1)]
        [InlineData(1, 1, 1, 1, 1, 1, 1, 1, 1)]
        public void Day2_Cube_AddCubeDraw_MaxRGBNoChange(int rStart, int gStart, int bStart, int rAdd, int gAdd, int bAdd, int rExp, int gExp, int bExp)
        {
            // Arrange
            var cube = new Day2.Game(1, rStart, gStart, bStart);
            // Act
            cube.AddCubeDraw(rAdd, gAdd, bAdd);
            var resultR = cube.MaxR;
            var resultG = cube.MaxG;
            var resultB = cube.MaxB;
            // Assert
            resultR.Should().Be(rExp);
            resultR.Should().BeOfType(typeof(int));
            resultR.Should().BeGreaterThanOrEqualTo(0);
            resultR.Should().BeGreaterThanOrEqualTo(rStart);
            resultG.Should().Be(gExp);
            resultG.Should().BeOfType(typeof(int));
            resultG.Should().BeGreaterThanOrEqualTo(0);
            resultG.Should().BeGreaterThanOrEqualTo(gStart);
            resultB.Should().Be(bExp);
            resultB.Should().BeOfType(typeof(int));
            resultB.Should().BeGreaterThanOrEqualTo(0);
            resultB.Should().BeGreaterThanOrEqualTo(bStart);
        }


        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1, 4, 2, 6)]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 2, 1, 3, 4)]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 3, 20, 13, 6)]
        [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 4, 14, 3, 15)]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 5, 6, 3, 2)]
        [InlineData("Game 22: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 22, 4, 2, 6)]
        public void Day2_Cube_ParseGame_MaxRGBMatches(string dataLine, int idExp, int rExp, int gExp, int bExp)
        {
            // Arrange
            var game = Day2.Cubes.ParseGame(dataLine);

            // Act
            var resultId = game.GameId;
            var resultR = game.MaxR;
            var resultG = game.MaxG;
            var resultB = game.MaxB;
            // Assert
            resultId.Should().Be(idExp);
            resultId.Should().BeOfType(typeof(int));
            resultR.Should().Be(rExp);
            resultR.Should().BeOfType(typeof(int));
            resultR.Should().BeGreaterThanOrEqualTo(0);
            resultG.Should().Be(gExp);
            resultG.Should().BeOfType(typeof(int));
            resultG.Should().BeGreaterThanOrEqualTo(0);
            resultB.Should().Be(bExp);
            resultB.Should().BeOfType(typeof(int));
            resultB.Should().BeGreaterThanOrEqualTo(0);
        }


        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", true)]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", true)]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", false)]
        [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", false)]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", true)]
        [InlineData("Game 22: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", true)]
        public void Day2_Game_Possible_expectedBool(string dataLine, bool expected)
        {
            // Arrange
            var game = Day2.Cubes.ParseGame(dataLine);

            // Act
            var result = game.Possible();
            // Assert
            result.Should().Be(expected);
        }


        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 48)]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 12)]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 1560)]
        [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 630)]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 36)]
        public void Day2_Game_GetPower_expectedInt(string dataLine, int expected)
        {
            // Arrange
            var game = Day2.Cubes.ParseGame(dataLine);

            // Act
            var result = game.GetPower();
            // Assert
            result.Should().Be(expected);
            result.Should().BeOfType(typeof(int));
            result.Should().BeGreaterThan(0);
        }


    }
}
