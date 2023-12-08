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




        public static IEnumerable<object[]> Day7_Hand_DetermineHand_Data()
        {
            yield return new object[]
            {
                "32T3K",
                Day7.Hand.handValues["One pair"]
            };
            yield return new object[]
            {
                "22222",
                Day7.Hand.handValues["Five of a kind"]
            };
            yield return new object[]
            {
                "44441",
                Day7.Hand.handValues["Four of a kind"]
            };
            yield return new object[]
            {
                "33312",
                Day7.Hand.handValues["Three of a kind"]
            };
            yield return new object[]
            {
                "44455",
                Day7.Hand.handValues["Full house"]
            };
            yield return new object[]
            {
                "33166",
                Day7.Hand.handValues["Two pair"]
            };
            yield return new object[]
            {
                "12345",
                Day7.Hand.handValues["High card"]
            };
        }
        [Theory]
        [MemberData(nameof(Day7_Hand_DetermineHand_Data))]
        public void Day7_Hand_DetermineHand(string handString,
            int expectedScore)
        {
            //Arrange

            //Act
            var hand = new Day7.Hand(handString);
            var resultScore = hand.DetermineHand();
            //Assert
            resultScore.Should().Be(expectedScore);
        }




    }
}
