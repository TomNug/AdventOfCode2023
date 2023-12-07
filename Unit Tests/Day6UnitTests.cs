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
        public static IEnumerable<object[]> Day6_Day6_ParseRaces_ReturnsRaces_Data()
        {
            yield return new object[]
            {
                new string[] {"Time:      7  15   30",
                "Distance:  9  40  200" },
                new List<Race> {new Race(7,9), new Race(15,40), new Race(30,200) }
            };
        }
        [Theory]
        [MemberData(nameof(Day6_Day6_ParseRaces_ReturnsRaces_Data))]
        public void Day6_Day6_ParseRaces_ReturnsRaces(string[] instructions, 
            List<Race> expected)
        {
            //Arrange

            //Act
            List<Race> resultRaces = Day6.Day6.ParseRaces(instructions);
            //Assert
            resultRaces.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<object[]> Day6_Race_CalculateNumberOfWinners_Data()
        {
            yield return new object[]
            {
                new Race(7,9), 4
            };
            yield return new object[]
            {
                new Race(15,40), 8
            };
            yield return new object[]
            {
                new Race(30,200), 9
            };
        }
        [Theory]
        [MemberData(nameof(Day6_Race_CalculateNumberOfWinners_Data))]
        public void Day6_Race_CalculateNumberOfWinners(Race testRace,
            int expected)
        {
            //Arrange

            //Act
            var result = testRace.CalculateNumberOfWinners();
            //Assert
            result.Should().Be(expected);
        }


    }
}
