

namespace Day5
{
    public class Day5SeedMaps
    {
        public static void Part1Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 1 %%%");

            Console.WriteLine(String.Format("The total points from the scratch cards is {0}", 5));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            Console.WriteLine(String.Format("You end up with {0} scratchcards", 5));
        }
        public static void Main(string[] args)
        {
            string samplePath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 5 - Seed Maps\Sample.txt";
            string fullPath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 5 - Seed Maps\Full.txt";
            string[] instructions = System.IO.File.ReadAllLines(fullPath);
            Part1Solution(instructions);
            Part2Solution(instructions);
        }
    }
}


