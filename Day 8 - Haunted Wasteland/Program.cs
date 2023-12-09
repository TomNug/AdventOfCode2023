using System.Text;
using System.Text.RegularExpressions;
using Day8;

namespace Day8
{
    public class Program
    {
        // Traverses the desert for part 1
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
        // Used in part 2
        // Identifies if a string ends in Z
        public static bool EndsInZ(string name)
        {
            if (name[2] != 'Z')
                    return false;
            return true;
        }

        // Calculates the number of steps from A to Z
        public static int CalculatePathLength(string turns, Dictionary<string, Node> nodes, string node)
        {
            // Number of steps taken along route
            int steps = 0;
            // Current turn (L or R) in pattern
            int turnsIndex = 0;

            while (!EndsInZ(node))
            {
                // Taking a step
                steps++;

                // Turn to take
                char turnToTake = turns[turnsIndex];

                // Turn
                node = nodes[node].Navigate(turnToTake);

                // Move to next instruction
                turnsIndex = (turnsIndex + 1) % turns.Length;
            }
            return steps;
        }
        
        // Takes a list of integers
        // Returns LCM
        public static long CalculatePathAlignment(List<int> pathLengths)
        {
            //pathLengths = new List<int> { 12, 18 }; // TEST, DELETE AFTER
            pathLengths.Sort();
            Day8.PrimeHelper.GeneratePrimes(pathLengths[pathLengths.Count - 1]);
            List<List<int>> factorsForEachPath = new List<List<int>>();

            foreach(int pathLength in pathLengths)
            {
                factorsForEachPath.Add(Day8.PrimeHelper.PrimeFactors(pathLength));
            }

            long lcm = Day8.LCMHelper.CalculateLCMFromListsOfFactors(factorsForEachPath);
            return lcm;
        }

        
        public static long TraverseDesertPart2(string turns, Dictionary<string, Node> nodes, List<string> currentNodes)
        {
            // Stores the path length from A-Z for each starting node
            // Assuming they loop perfectly, with each loop of an equal length
            List<int> pathLengths = new List<int>();

            foreach(string node in currentNodes)
            {
                pathLengths.Add(CalculatePathLength(turns, nodes, node));
            }

            long pathAlignment = CalculatePathAlignment(pathLengths);

            return pathAlignment;
        }


        public static void Part1Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 1 %%%");
            // First line is the turn sequence
            string patternInput = instructions[0];
            Dictionary<string, Node> nodes = Day8.ParserHelper.ParseInstructions(instructions);
            int steps = TraverseDesert(patternInput, nodes);

            Console.WriteLine(String.Format("You get to ZZZ in {0} steps", steps));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            // First line is the turn sequence
            string patternInput = instructions[0];
            (Dictionary<string, Node>, List<string>) nodesStarts = Day8.ParserHelper.ParseInstructionsPart2(instructions);
            long steps = TraverseDesertPart2(patternInput, nodesStarts.Item1, nodesStarts.Item2);



            Console.WriteLine(String.Format("You get to ZZZ in {0} steps", steps));
        }
        public static void Main(string[] args)
        {
            string path = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\";
            string day = "Day 8 - Haunted Wasteland";

            string samplePath = path + day + @"\Sample.txt";
            string samplePath2 = path + day + @"\Sample2.txt";
            string fullPath = path + day + @"\Full.txt";
            string[] instructionsSample = System.IO.File.ReadAllLines(samplePath);
            string[] instructionsSample2 = System.IO.File.ReadAllLines(samplePath2);
            string[] instructionsFull = System.IO.File.ReadAllLines(fullPath);
            Part1Solution(instructionsFull);
            Part2Solution(instructionsFull);
        }
    }
}


