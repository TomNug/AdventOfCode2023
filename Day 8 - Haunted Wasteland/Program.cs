using System.Text;
using System.Text.RegularExpressions;

namespace Day8
{
    public class Program
    {
        public static Dictionary<string, Node> ParseInstructions(string[] instructions)
        {
            Dictionary<string, Node> result = new Dictionary<string, Node>();

            for (int line=2; line<instructions.Length; line++)
            {
                string pattern = @"([A-Z]{3}) = \(([A-Z]{3}), ([A-Z]{3})\)";
                Match match = Regex.Match(instructions[line], pattern);
                string name = match.Groups[1].Value;
                string left = match.Groups[2].Value;
                string right = match.Groups[3].Value;

                Node newNode = new Node(left, right);
                result.Add(name, newNode);
            }
            return result;
        }

        public static int TraverseDesert(string turns, Dictionary<string, Node> nodes)
        {
            int steps = 0;

            int turnsIndex = 0;
            string node = "AAA";

            while (node != "ZZZ")
            {
                // Taking a step
                steps++;

                // Turn to take
                char turnToTake = turns[turnsIndex];

                // New node
                node = nodes[node].Navigate(turnToTake);

                // Move to next instruction
                turnsIndex = (turnsIndex + 1) % turns.Length;
            }



            return steps;
        }
        public static void Part1Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 1 %%%");
            // First line is the turn sequence
            string patternInput = instructions[0];
            Dictionary<string, Node> nodes = ParseInstructions(instructions);
            int steps = TraverseDesert(patternInput, nodes);

            Console.WriteLine(String.Format("You get to ZZZ in {0} steps", steps));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            Console.WriteLine(String.Format("The total winnings are {0}", 5));
        }
        public static void Main(string[] args)
        {
            string path = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\";
            string day = "Day 8 - Haunted Wasteland";

            string samplePath = path + day + @"\Sample.txt";
            string fullPath = path + day + @"\Full.txt";
            string[] instructions = System.IO.File.ReadAllLines(fullPath);
            Part1Solution(instructions);
            Part2Solution(instructions);
        }
    }
}


