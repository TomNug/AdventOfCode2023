using System.Text;
using System.Text.RegularExpressions;

namespace Day10
{
    public class Program
    {
        public static char[,] ParseGrid(string[] instructions)
        {
            char[,] grid = new char[instructions.Length, instructions[0].Length];
            for (int i = 0; i < instructions.Length; i++)
                for (int j = 0; j < instructions[0].Length; j++)
                    grid[i, j] = (char)(instructions[i][j]);
            return grid;
        }
        public static void Part1Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 1 %%%");
            char[,] grid = ParseGrid(instructions);
            int maxSteps = 5;
            Console.WriteLine(String.Format("The farthest point is {0} steps away", maxSteps));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            int maxSteps = 5;
            Console.WriteLine(String.Format("The farthest point is {0} steps away", maxSteps));
        }
        public static void Main(string[] args)
        {
            string path = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\";
            string day = "Day 10 - Pipe Maze";

            string samplePath = path + day + @"\Sample.txt";
            string samplePath2 = path + day + @"\Sample2.txt";
            string fullPath = path + day + @"\Full.txt";
            string[] instructionsSample = System.IO.File.ReadAllLines(samplePath);
            //string[] instructionsSample2 = System.IO.File.ReadAllLines(samplePath);
            string[] instructionsFull = System.IO.File.ReadAllLines(fullPath);
            Part1Solution(instructionsSample);
            Part2Solution(instructionsSample);
        }
    }
}


