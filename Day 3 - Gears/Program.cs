using System.Text.RegularExpressions;

namespace Day3
{
    
    public class Gears
    {
        public char[,] ParseEngineArray(string[] lines)
        {
            List<List<char>> list2D = new List<List<char>>();
            return new char[2, 1] { { '1' }, { '2' } };
        }

        public static char[] ParseLine(string line)
        {
            return line.ToCharArray();
        }
        public static void Part1Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 1 %%%");
            Console.WriteLine(String.Format("Final sum of part numbers is {0}", 0));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            Console.WriteLine(String.Format("Final sum of power is {0}", 0));
        }
        public static void Main(string[] args)
        {
            string samplePath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 3 - Gears\Sample.txt";
            string fullPath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 2 - Cube Game\Full.txt";
            string[] instructions = System.IO.File.ReadAllLines(samplePath);
            Part1Solution(instructions);
            Part2Solution(instructions);
        }
    }
}


