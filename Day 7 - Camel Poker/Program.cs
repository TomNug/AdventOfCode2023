using System.Text;
using System.Text.RegularExpressions;

namespace Day7
{
    public class Program
    {
        
        public static void Part1Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 1 %%%");

            Console.WriteLine(String.Format("The total winnings are {0}", 5));
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
            string[] instructions = System.IO.File.ReadAllLines(samplePath);
            Part1Solution(instructions);
            Part2Solution(instructions);
        }
    }
}


