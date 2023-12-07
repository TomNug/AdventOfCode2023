using Day5;
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


        public static IEnumerable<Object[]> Day5_Day5MapsOfSeeds_ProcessSeedsForPart2_ReturnSmallestInt_Data()
        {
            yield return new Object[] { new string[]
            {
                "seeds: 50 20",
                "seed-to-soil map:",
                "0 60 10",
                "",
                "soil-to-fertilizer map:",
                "20 0 20",
                "90 59 2",
                "",
                "fertilizer-to-water map:",
                "75 25 10",
                "0 54 10"
            }, 0 };
            yield return new Object[] { new string[]
            {
                "seeds: 79 14 55 13",
                "",
                "seed - to - soil map:",
                "50 98 2",
                "52 50 48",
                "",
                "soil - to - fertilizer map:",
                "0 15 37",
                "37 52 2",
                "39 0 15",
                "",
                "fertilizer - to - water map:",
                "49 53 8",
                "0 11 42",
                "42 0 7",
                "57 7 4",
                "",
                "water - to - light map:",
                "88 18 7",
                "18 25 70",
                "",
                "light - to - temperature map:",
                "45 77 23",
                "81 45 19",
                "68 64 13",
                "",
                "temperature - to - humidity map:",
                "0 69 1",
                "1 0 69",
                "",
                "humidity - to - location map:",
                "60 56 37",
                "56 93 4"
            }, 46 };
        }
        [Theory]
        [MemberData(nameof(Day5_Day5MapsOfSeeds_ProcessSeedsForPart2_ReturnSmallestInt_Data))]
        public void Day5_Day5MapsOfSeeds_ProcessSeedsForPart2_ReturnSmallestInt(string[] instructions, int expected)
        {
            // Arrange

            // Act
            Day5MapsOfSeeds.Reset();
            Day5MapsOfSeeds.ParseMaps(instructions);
            long result = Day5MapsOfSeeds.ProcessSeedsForPart2();
            // Assert
            result.Should().Be(expected);
        }

        
        [Theory]
        [InlineData("seeds: 79 14 55 13", 46)]
        [InlineData("seeds: 82 1", 46)]
        [InlineData("seeds: 40 20", 15)]
        [InlineData("seeds: 82 1 40 20", 15)]
        public void Day5_Day5MapsOfSeeds_ProcessSeedsForPart2_MapSeeds(string seed, int expected)
        {
            // Arrange
            string[] instructions = {
                seed,
                "",
                "seed - to - soil map:",
                "50 98 2",
                "52 50 48",
                "",
                "soil - to - fertilizer map:",
                "0 15 37",
                "37 52 2",
                "39 0 15",
                "",
                "fertilizer - to - water map:",
                "49 53 8",
                "0 11 42",
                "42 0 7",
                "57 7 4",
                "",
                "water - to - light map:",
                "88 18 7",
                "18 25 70",
                "",
                "light - to - temperature map:",
                "45 77 23",
                "81 45 19",
                "68 64 13",
                "",
                "temperature - to - humidity map:",
                "0 69 1",
                "1 0 69",
                "",
                "humidity - to - location map:",
                "60 56 37",
                "56 93 4" };
            // Act
            Day5MapsOfSeeds.Reset();
            Day5MapsOfSeeds.ParseMaps(instructions);
            long result = Day5MapsOfSeeds.ProcessSeedsForPart2();
            // Assert
            result.Should().Be(expected);
        }



        public static IEnumerable<object[]> Day5_Map_MapRangeReturningMappedUnmapped_Data()
        {
            yield return new object[]
            {
                30L, 0L, 10L, // Mapping string "to-from-range"
                (0L, 9L), // Input range low-high
                (30L, 39L), // Expected mapped output
                new List<(long, long)>
                {
                }
            };
            yield return new object[]
            {
                0L, 40L, 20L, // Mapping string "to-from-range"
                (30L, 80L), // Input range low-high
                (0L, 19L), // Expected mapped output
                new List<(long, long)>
                {
                    (30L, 39L), // Expected below
                    (60L, 80L), // Expected above
                },
            };
        }
        [Theory]
        [MemberData(nameof(Day5_Map_MapRangeReturningMappedUnmapped_Data))]
        public void Day5_Map_MapRangeReturningMappedUnmapped(long mapTo, long mapFrom, long mapRange,
            (long,long) testInputRange,
            (long, long) expectedMapped, 
            List<(long, long)> expectedUnmapped)
        {
            // Arrange
            Map map = new Map(mapTo, mapFrom, mapRange);
            // Act
            var result = map.MapRangeReturningMappedUnmapped(testInputRange);
            var resultMapped = expectedMapped;
            var resultUnmapped = expectedUnmapped;

            // Assert
            resultMapped.Should().Be(expectedMapped);
            resultUnmapped.Should().BeSameAs(expectedUnmapped);
        }


    }
}
