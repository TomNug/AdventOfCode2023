

namespace Day4
{
    public class Day4ScratchCards
    {
        public static void Part1Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 1 %%%");
            Console.WriteLine(String.Format("The total points is {0}", 5));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            Console.WriteLine(String.Format("The sum of all gear ratios is {0}", 1));
        }
        public static void Main(string[] args)
        {
            string samplePath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 4 - Scratch Cards\Sample.txt";
            string fullPath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 3 - Gears\Full.txt";
            string[] instructions = System.IO.File.ReadAllLines(samplePath);
            Part1Solution(instructions);
            Part2Solution(instructions);
        }
    }
}


