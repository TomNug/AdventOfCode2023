using Day4;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests
{
    public class Day5UnitTests
    {
        [Theory]
        [InlineData(50, 98, 2, 98, 50)]
        [InlineData(50, 98, 2, 99, 51)]
        [InlineData(50, 98, 2, 70, 70)]
        [InlineData(52, 50, 48, 50, 52)]
        [InlineData(52, 50, 48, 51, 53)]
        [InlineData(52, 50, 48, 96, 98)]
        [InlineData(52, 50, 48, 97, 99)]
        [InlineData(52, 50, 48, 10, 10)]
        public void Day5_Map_MapValue_ReturnInt(int destinationStart, int sourceStart, int range, int inputValue, int expected)
        {
            // Arrange
            var map = new Day5.Map(destinationStart, sourceStart, range);
            // Act
            var result = map.MapValue(inputValue);

            // Assert
            result.Should().Be(expected);
        }








    }
}
