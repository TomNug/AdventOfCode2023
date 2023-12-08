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
        public static readonly Dictionary<string, int> handValues = new Dictionary<string, int>
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
            List<int> frequencyInts = new List<int>();

            foreach(KeyValuePair<char, int> c in cardFrequencies)
            {
                frequencyInts.Add(c.Value);
            }    

            frequencyInts.Sort((a, b) => b.CompareTo(a));

            if (frequencyInts[0] == 5)
                return handValues["Five of a kind"];
            if (frequencyInts[0] == 4)
                return handValues["Four of a kind"];
            if (frequencyInts[0] == 3 && frequencyInts[1] == 2)
                return handValues["Full house"];
            if (frequencyInts[0] == 3)
                return handValues["Three of a kind"];
            if (frequencyInts[0] == 2 && frequencyInts[1] == 2)
                return handValues["Two pair"];
            if (frequencyInts[0] == 2)
                return handValues["One pair"];
            else
                return handValues["High card"];
        }
    }
}
