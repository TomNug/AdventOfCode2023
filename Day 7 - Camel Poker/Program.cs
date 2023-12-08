using System.Text;
using System.Text.RegularExpressions;

namespace Day7
{
    public class Program
    {
        public static List<Hand> ParseHands(string[] instructions)
        {
            List<Hand> hands = new List<Hand>();
            foreach(string instruction in instructions)
            {
                string pattern = @"([AKQJT987654321]+) (\d+)";
                Match match = Regex.Match(instruction, pattern);
                string cards = match.Groups[1].Value;
                int bid = Convert.ToInt32(match.Groups[2].Value);
                Hand hand = new Hand(cards, bid);
                hands.Add(hand);
            }
            return hands;
        }
        public static void Part1Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 1 %%%");
            List<Hand> hands = ParseHands(instructions);

            // Sort the hands by their value
            hands.Sort();

            // Maintain sum of (bid * rank)
            long sumOfWinnings = 0;
            for (int rank = 0; rank < hands.Count; rank++)
                sumOfWinnings += hands[rank].bid * (rank + 1);

            Console.WriteLine(String.Format("The total winnings are {0}", sumOfWinnings));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            Console.WriteLine(String.Format("The total winnings are {0}", 5));
        }
        public static void Main(string[] args)
        {


            string samplePath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 7 - Camel Poker\Sample.txt";
            string fullPath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 7 - Camel Poker\Full.txt";
            string[] instructions = System.IO.File.ReadAllLines(fullPath);
            Part1Solution(instructions);
            Part2Solution(instructions);
        }
    }
}


