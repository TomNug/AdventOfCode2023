using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day12;
using FluentAssertions;

namespace Unit_Tests
{
    public class Day12UnitTests
    {
        public static IEnumerable<object[]> Day12_HotSpring_ErrorCheckSpring_ReturnBool_Data()
        {
            yield return new object[]
            {
                "...#...#",
                new List<int>{1,1 },
                true
            };
            yield return new object[]
            {
                "####.###",
                new List<int>{4,3 },
                true
            };
            yield return new object[]
            {
                "####..##",
                new List<int>{4,3 },
                false
            };
            yield return new object[]
            {
                "........",
                new List<int>{ },
                true
            };
            yield return new object[]
            {
                "########",
                new List<int>{8 },
                true
            };
        }

        [Theory]
        [MemberData(nameof(Day12_HotSpring_ErrorCheckSpring_ReturnBool_Data))]
        public void Day12_HotSpring_ErrorCheckSpring_ReturnBool(string line, List<int> groupsBroken, bool expected)
        {
            // Arrange
            HotSpring spring = new HotSpring("", new List<int> { }, groupsBroken);




            // Act
            var result = spring.ErrorCheckSpring(line);

            // Assert
            result.Should().Be(expected);
        }

    }
}

