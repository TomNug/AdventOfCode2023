using System.Text;
using System.Text.RegularExpressions;

namespace Day11
{
    public class Program
    {
 
        public static void Part1Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 1 %%%");
            
            Console.WriteLine(String.Format("The farthest point is {0} steps away", 5));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            
            Console.WriteLine(String.Format("The number of inside tiles is {0}", 5));
        }
        public static void Main(string[] args)
        {
            string path = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\";
            string day = "Day 11 - Astonomy";

            string samplePath = path + day + @"\Sample.txt";
            string samplePath2 = path + day + @"\Sample2.txt";
            string fullPath = path + day + @"\Full.txt";
            string[] instructionsSample = System.IO.File.ReadAllLines(samplePath);
            //string[] instructionsSample2 = System.IO.File.ReadAllLines(samplePath);
            string[] instructionsFull = System.IO.File.ReadAllLines(fullPath);
            Part1Solution(samplePath);
            Part2Solution(samplePath);
        }
    }
}


