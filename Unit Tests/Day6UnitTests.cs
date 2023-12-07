using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day6;
using FluentAssertions;

namespace Unit_Tests
{
    public class Day6UnitTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 1)]
        public void Day6_Test(int input, int expected)
        {
            // Arrange

            // Act

            // Assert
            input.Should().Be(expected);
        }
    }
}
