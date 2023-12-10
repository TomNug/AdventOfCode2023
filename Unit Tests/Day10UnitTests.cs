using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day10;
using FluentAssertions;

namespace Day10
{
    public class Day10UnitTests
    {
        public static IEnumerable<object[]> Day10_TraversalHelper_FindAdjacentPositions_Return2Coords_Data()
        {
            yield return new object[]
            {
                (1, 1), // From
                new List<(int,int)> {(1,2), (2,1)} // To
            };
            yield return new object[]
            {
                (1, 3), // From
                new List<(int,int)> {(2,3), (1,2)} // To
            };
            yield return new object[]
            {
                (4,2), // From
                new List<(int,int)> {(4,1), (3,2)} // To
            };

        }
        [Theory]
        [MemberData(nameof(Day10_TraversalHelper_FindAdjacentPositions_Return2Coords_Data))]
        public void Day10_TraversalHelper_FindAdjacentPositions_Return2Coords((int,int) coord, List<(int,int)> expected)
        {
            //Arrange
            char[,] grid = new char[,] {    {'.', '.' , '.' , '.' , '.' },
                                            {'.', 'F' , '-' , '7' , '.' },
                                            {'.', '|' , '.' , '|' , '.' },
                                            {'.', '|' , 'F' , 'J' , '.' },
                                            {'.', 'L' , 'J' , '.' , '.' },
                                            {'.', '.' , '.' , '.' , '.' }};

            //Act
            TraversalHelper helper = new TraversalHelper();
            helper.SetGrid(grid);
            ((int,int),(int,int)) result = helper.FindAdjacentPositions(coord);
            List<(int, int)> resultAsList = new List<(int, int)>();
            resultAsList.Add(result.Item1);
            resultAsList.Add(result.Item2);

            //Assert
            resultAsList.Should().BeEquivalentTo(expected);
        }


        public static IEnumerable<object[]> Day10_TraversalHelper_NextStepThroughMaze_CorrectCoord_Data()
        {
            yield return new object[]
            {
                (1, 1), // At
                (1,2), // Prev
                (2,1) // Expected
            };
            yield return new object[]
            {
                (1, 3), // At
                (1, 2), // Prev
                (2, 3) // Expected
            };
            yield return new object[]
            {
                (2, 1), // At
                (1, 1), // Prev
                (3, 1) // Expected
            };

        }
        [Theory]
        [MemberData(nameof(Day10_TraversalHelper_NextStepThroughMaze_CorrectCoord_Data))]
        public void Day10_TraversalHelper_NextStepThroughMaze_CorrectCoord((int, int) at, (int,int) prev, (int,int) expected)
        {
            //Arrange
            char[,] grid = new char[,] {    {'.', '.' , '.' , '.' , '.' },
                                            {'.', 'F' , '-' , '7' , '.' },
                                            {'.', '|' , '.' , '|' , '.' },
                                            {'.', '|' , 'F' , 'J' , '.' },
                                            {'.', 'L' , 'J' , '.' , '.' },
                                            {'.', '.' , '.' , '.' , '.' }};

            //Act
            TraversalHelper helper = new TraversalHelper();
            helper.SetGrid(grid); 
            (int, int) result = helper.NextStepThroughMaze(prev, at);

            //Assert
            result.Should().Be(expected);
        }
    }
}
