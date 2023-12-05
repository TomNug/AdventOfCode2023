using Day4;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Tests
{
    public class Day4UnitTests
    {
        public static IEnumerable<Object[]> Day4_ScratchCard_ScratchCard_ScratchCardConstructed_Data()
        {
            yield return new Object[] { "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 1, new HashSet<int> { 41, 48, 83, 86, 17 },
                new HashSet<int> { 83, 86,  6, 31, 17,  9, 48, 53 } };
            yield return new Object[] { "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2, new HashSet<int> { 13, 32, 20, 16, 61 },
                new HashSet<int> { 61, 30, 68, 82, 17, 32, 24, 19 } };
            yield return new Object[] { "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 6, new HashSet<int> { 31, 18, 13, 56, 72 },
                new HashSet<int> { 74, 77, 10, 23, 35, 67, 36, 11 } };
        }
        [Theory]
        [MemberData(nameof(Day4_ScratchCard_ScratchCard_ScratchCardConstructed_Data))]
        public void Day4_ScratchCard_ScratchCard_ScratchCardConstructed(string line, int expectedCardNum, 
            HashSet<int> expectedWinning, HashSet<int> expectedNumbers)
        {
            // Arrange

            // Act
            var resultScratchCard = new ScratchCard(line);
            // Assert

            resultScratchCard.Number.Should().Be(expectedCardNum);
            resultScratchCard.WinningNumbers.SetEquals(expectedWinning).Should().BeTrue();
            resultScratchCard.Numbers.SetEquals(expectedNumbers).Should().BeTrue();
        }

        public static IEnumerable<Object[]> Day4_ScratchCard_GetPoints_ReturnInt_Data()
        {
            yield return new Object[] { "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 8 };
            yield return new Object[] { "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2};
            yield return new Object[] { "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 2};
            yield return new Object[] { "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 1};
            yield return new Object[] { "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0};
            yield return new Object[] { "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 0 };
        }
        [Theory]
        [MemberData(nameof(Day4_ScratchCard_GetPoints_ReturnInt_Data))]
        public void Day4_ScratchCard_GetPoints_ReturnInt(string line, int expected)
        {
            // Arrange
            var scratchCard = new ScratchCard(line);
            // Act
            var result = scratchCard.Points;
            // Assert

            result.Should().Be(expected);
        }



        public static IEnumerable<Object[]> Day4_ScratchCardPool_CountNumCards_ReturnsInt_Data()
        {
            yield return new Object[] { 
            new string[] {"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
                "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
                "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
                "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
                "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
                "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11" }, 30 };
        }
        [Theory]
        [MemberData(nameof(Day4_ScratchCardPool_CountNumCards_ReturnsInt_Data))]
        public void Day4_ScratchCardPool_CountNumCards_ReturnsInt(string[] lines, int expected)
        {
            // Arrange
            ScratchCardPool pool = new ScratchCardPool(lines);

            // Act
            pool.ScoreAllCards();
            var result = pool.CountNumCards();
            
            // Assert
            result.Should().Be(expected);
        }



    }
}
