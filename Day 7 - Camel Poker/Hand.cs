using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    public class Hand: IComparable<Hand>
    {
        public string cards { get; set; }
        public int bid { get; set; }
        public int handRank { get; set; }
        public int numJokers { get; set; }
        public Dictionary<char, int> cardFrequencies { get; set; }
        public Hand(string cards, int bid)
        {
            this.cards = cards;
            this.bid = bid;
            cardFrequencies = new Dictionary<char, int>();
            CountCards();
            handRank = DetermineHand();
        }

        // Dictionary to store the values of each hand
        public static readonly Dictionary<string, int> handStrength = new Dictionary<string, int>
        {
            { "Five of a kind", 6 },
            { "Four of a kind", 5 },
            { "Full house", 4 },
            { "Three of a kind", 3 },
            { "Two pair", 2 },
            { "One pair", 1 },
            { "High card", 0 },
        };

        // Dictionary to store the values of each card
        public static readonly Dictionary<char, int> cardStrength = new Dictionary<char, int>
        {
            { 'A', 13 },
            { 'K', 12 },
            { 'Q', 11 },
            //{ 'J', 10 },
            { 'T', 9 },
            { '9', 8 },
            { '8', 7 },
            { '7', 6 },
            { '6', 5 },
            { '5', 4 },
            { '4', 3 },
            { '3', 2 },
            { '2', 1 },
            { '1', 0 },
            { 'J', -1 },
        };

        // Reads the string representing the hard
        // Stores the frequency of each card
        public void CountCards()
        {
            foreach(char c in cards)
            {
                // Don't add jokers to the hand
                if (c == 'J')
                    numJokers++;
                else if (cardFrequencies.ContainsKey(c))
                    cardFrequencies[c]++;
                else
                    cardFrequencies.Add(c, 1);
            }
        }
        public int CompareTo(Hand? other)
        {
            if (handRank > other.handRank)
                return 1;
            else if (handRank < other.handRank)
                return -1;
            else
            {
                // Are tied on quality of hand
                // Now run card by card comparison
                for(int i = 0; i < this.cards.Length; i++)
                {
                    int thisCard = Day7.Hand.cardStrength[cards[i]];
                    int otherCard = Day7.Hand.cardStrength[other.cards[i]];
                    if (thisCard > otherCard)
                        return 1;
                    else if (thisCard < otherCard)
                        return -1;
                }
                // Shouldn't reach here (know this from problem description)
                return 0;
            }
        }

        // Overload the > operator
        public static bool operator >(Hand hand1, Hand hand2)
        {
            return hand1.CompareTo(hand2) > 0;
        }

        // Overload the < operator (optional)
        public static bool operator <(Hand hand1, Hand hand2)
        {
            return hand1.CompareTo(hand2) < 0;
        }

        // Returns the number repesenting the value of the hand
        public int DetermineHand()
        {
            List<int> frequencyInts = new List<int>();

            foreach(KeyValuePair<char, int> c in cardFrequencies)
            {
                frequencyInts.Add(c.Value);
            }

            frequencyInts.Sort((a, b) => b.CompareTo(a));
            if (numJokers == 5) // All jokers, make a FIVE
                return handStrength["Five of a kind"];
            else if ((frequencyInts[0] + numJokers) == 5) // Most common + jokers makes FIVE
                return handStrength["Five of a kind"];
            else if ((frequencyInts[0] + numJokers) == 4) // Most common + jokers makes FOUR
                return handStrength["Four of a kind"];
            else if ((frequencyInts[0] + frequencyInts[1] + numJokers) == 5) // Two most common + jokers makes five => FULL HOUSE
                return handStrength["Full house"];
            else if (frequencyInts[0] + numJokers == 3) // Most common + jokers makes THREE
                return handStrength["Three of a kind"];
            else if (frequencyInts[0] == 2 && frequencyInts[1] == 2) // Joker should be used to make THREE instead
                return handStrength["Two pair"];
            else if (frequencyInts[0] + numJokers == 2) // No pairs, + jokers makes TWO
                return handStrength["One pair"];
            else // No pairs, no jokers
                return handStrength["High card"];
        }
    }
}
// Jokers make a full house
// Otherwise jokers make a 3 of a kind