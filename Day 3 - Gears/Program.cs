using System.Text;
using System.Text.RegularExpressions;

namespace Day3
{
    
    
    public class GearRatios
    {
        public static char[,] ParseEngineArray(string[] lines)
        {
            char[,] grid = new char[lines.Length, lines[0].Length];
            for(int i = 0; i < lines.Length;i++)
            {
                char[] line = ParseLine(lines[i]);
                for (int j = 0; j < line.Length; j++)
                    grid[i, j] = line[j];
            }
            return grid;
        }

        public static char[] ParseLine(string line)
        {
            return line.ToCharArray();
        }
        public static void Part1Solution(string[] instructions)
        {
            char[,] grid = ParseEngineArray(instructions);
            Engine engine = new Engine(grid);
            engine.UpdateFlags();
            int sumOfIncluded = engine.CalcSumIncluded();
            Console.WriteLine("\n%%% Part 1 %%%");
            Console.WriteLine(String.Format("Final sum of included part numbers is {0}", sumOfIncluded));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            char[,] grid = ParseEngineArray(instructions);
            Engine engine = new Engine(grid);
            engine.FindGears();
            engine.UpdateFlags();
            engine.CalcGearAdjacentNumbers();
            int sumOfGearRatios = engine.GetSumOfAllGearRatios();
            Console.WriteLine(String.Format("The sum of all gear ratios is {0}", sumOfGearRatios));
        }
        public static void Main(string[] args)
        {
            string samplePath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 3 - Gears\Sample.txt";
            string fullPath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 3 - Gears\Full.txt";
            string[] instructions = System.IO.File.ReadAllLines(fullPath);
            Part1Solution(instructions);
            Part2Solution(instructions);
        }
    }
}


