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
        public Dictionary<char, int> cardFrequencies { get; set; }
        public Hand(string cards)
        {
            this.cards = cards;
            cardFrequencies = new Dictionary<char, int>();
            CountCards();
        }

        // Dictionary to store the values of each hand
        private static readonly Dictionary<string, int> handValues = new Dictionary<string, int>
        {
            { "Five of a kind", 6 },
            { "Four of a kind", 5 },
            { "Full house", 4 },
            { "Three of a kind", 3 },
            { "Two pair", 2 },
            { "One pair", 1 },
            { "High card", 0 },
        };

        // Reads the string representing the hard
        // Stores the frequency of each card
        public void CountCards()
        {
            foreach(char c in cards)
            {
                if (cardFrequencies.ContainsKey(c))
                    cardFrequencies[c]++;
                else
                    cardFrequencies.Add(c, 1);
            }
        }
        public int CompareTo(Hand? other)
        {
            throw new NotImplementedException();
        }

        // Returns the number repesenting the value of the hand
        public int DetermineHand()
        {
            int highestFrequency = 0;

            foreach(char c in cards)
            {

            }
            return 5;
        }
    }
}
