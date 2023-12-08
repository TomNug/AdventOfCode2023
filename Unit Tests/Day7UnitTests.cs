using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day7;
using FluentAssertions;

namespace Unit_Tests
{
    public class Day7UnitTests
    {
        public static IEnumerable<object[]> Day7_Hand_CountCards_Data()
        {
            yield return new object[]
            {
                "32T3K",
                new Dictionary<char, int>{{'3',2 }, {'2',1 }, {'T',1 }, {'K',1 } }
            };
        }
        [Theory]
        [MemberData(nameof(Day7_Hand_CountCards_Data))]
        public void Day7_Hand_CountCards(string handString,
            Dictionary<char, int> expected)
        {
            //Arrange

            //Act
            var hand = new Day7.Hand(handString);
            var resultDictionary = hand.cardFrequencies;
            //Assert
            resultDictionary.Should().BeEquivalentTo(expected);
        }

    }
}
