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
        Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
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
    }
}
