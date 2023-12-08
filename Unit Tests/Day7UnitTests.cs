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
            var hand = new Day7.Hand(handString, 5);
            var resultDictionary = hand.cardFrequencies;
            //Assert
            resultDictionary.Should().BeEquivalentTo(expected);
        }




        public static IEnumerable<object[]> Day7_Hand_DetermineHand_Data()
        {
            yield return new object[]
            {
                "32T3K",
                Day7.Hand.handStrength["One pair"]
            };
            yield return new object[]
            {
                "22222",
                Day7.Hand.handStrength["Five of a kind"]
            };
            yield return new object[]
            {
                "44441",
                Day7.Hand.handStrength["Four of a kind"]
            };
            yield return new object[]
            {
                "33312",
                Day7.Hand.handStrength["Three of a kind"]
            };
            yield return new object[]
            {
                "44455",
                Day7.Hand.handStrength["Full house"]
            };
            yield return new object[]
            {
                "33166",
                Day7.Hand.handStrength["Two pair"]
            };
            yield return new object[]
            {
                "12345",
                Day7.Hand.handStrength["High card"]
            };
            // Tests to check Jokers behave as expected
            
            // All jokers
            yield return new object[]
            {
                "JJJJJ",
                Day7.Hand.handStrength["Five of a kind"]
            };

            // Four jokers
            yield return new object[]
            {
                "1JJJJ",
                Day7.Hand.handStrength["Five of a kind"]
            };

            // Three jokers
            yield return new object[]
            {
                "12JJJ",
                Day7.Hand.handStrength["Four of a kind"]
            };
            yield return new object[]
            {
                "22JJJ",
                Day7.Hand.handStrength["Five of a kind"]
            };

            // Two Jokers
            yield return new object[]
            {
                "123JJ",
                Day7.Hand.handStrength["Three of a kind"]
            };
            yield return new object[]
            {
                "112JJ",
                Day7.Hand.handStrength["Four of a kind"]
            };
            yield return new object[]
            {
                "111JJ",
                Day7.Hand.handStrength["Five of a kind"]
            };

            // One joker
            yield return new object[]
            {
                "1234J",
                Day7.Hand.handStrength["One pair"]
            };
            yield return new object[]
            {
                "1123J",
                Day7.Hand.handStrength["Three of a kind"]
            };
            yield return new object[]
            {
                "1122J",
                Day7.Hand.handStrength["Full house"]
            };
            yield return new object[]
            {
                "1112J",
                Day7.Hand.handStrength["Four of a kind"]
            };
            yield return new object[]
            {
                "1111J",
                Day7.Hand.handStrength["Five of a kind"]
            };
        }
        [Theory]
        [MemberData(nameof(Day7_Hand_DetermineHand_Data))]
        public void Day7_Hand_DetermineHand(string handString,
            int expectedScore)
        {
            //Arrange

            //Act
            var hand = new Day7.Hand(handString, 5);
            var resultScore = hand.DetermineHand();
            //Assert
            resultScore.Should().Be(expectedScore);
        }


        public static IEnumerable<object[]> Day7_Hand_CompareTo_Data()
        {
            yield return new object[]
            {
                "11111", // Wins with five of a kind
                "22221",
                true
            };
            yield return new object[]
            {
                "12345",
                "44433", // Wins with full house
                false
            };
            yield return new object[]
            {
                "22233",
                "22244", // Wins on tie
                false
            };
            yield return new object[]
            {
                "12345",
                "12346", // Wins on tie
                false
            };
            yield return new object[]
            {
                "11JJJ",
                "11111", // Wins on tie
                false
            };
            yield return new object[]
            {
                "11111",// Wins on tie
                "111JJ", 
                false
            };
        }
        [Theory]
        [MemberData(nameof(Day7_Hand_CompareTo_Data))]
        public void Day7_Hand_CompareTo(string handString1 , string handString2,
            bool expected)
        {
            //Arrange

            //Act
            var hand1 = new Day7.Hand(handString1, 5);
            var hand2 = new Day7.Hand(handString2, 5);
            bool comparison = hand1 > hand2;

            var result = (comparison == expected);
            //Assert
            result.Should().BeTrue();
        }

    }
}
