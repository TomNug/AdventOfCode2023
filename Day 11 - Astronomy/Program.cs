using System.Text;
using System.Text.RegularExpressions;

namespace Day11
{
    public class Program
    {
        public static List<(long, long)> ParseAndExpandGalaxy(string[] instructions, int expansionMultiplier)
        {
            bool[] rowHasGalaxy = new bool[instructions.Length];
            bool[] colHasGalaxy = new bool[instructions[0].Length];

            List<(long, long)> galaxies = new List<(long, long)>();

            for (int row = 0; row < instructions.Length; row++)
            {
                for (int col = 0; col < instructions[0].Length; col++)
                {
                    char c = instructions[row][col];
                    if (c == '#')
                    {
                        galaxies.Add((row, col));
                        rowHasGalaxy[row] = true;
                        colHasGalaxy[col] = true;
                    }
                }
            }

            // Expand rows
            for (int row = rowHasGalaxy.Length - 1; row >= 0; row--)
            {
                if (!rowHasGalaxy[row])
                {
                    // Expand the x coordinate of any x greater than row
                    for (int g = 0; g < galaxies.Count; g++)
                    {
                        if (galaxies[g].Item1 > row)
                        {
                            galaxies[g] = (galaxies[g].Item1 + expansionMultiplier - 1, galaxies[g].Item2);
                        }
                    }
                }
            }

            // Expand cols
            for (int col = colHasGalaxy.Length - 1; col >= 0; col--)
            {
                if (!colHasGalaxy[col])
                {
                    // Expand the y coordinate of any x greater than row
                    for (int g = 0; g < galaxies.Count; g++)
                    {
                        if (galaxies[g].Item2 > col)
                        {
                            galaxies[g] = (galaxies[g].Item1, galaxies[g].Item2 + expansionMultiplier - 1);
                        }
                    }
                }
            }

            return (galaxies);
        }
        public static void Part1Solution(string[] instructions)
        {

            Console.WriteLine("\n%%% Part 1 %%%");
            List<(long, long)> galaxies = ParseAndExpandGalaxy(instructions, 2);
            long sum = ShortestPathCalculator.CalculateSumOfShortestPaths(galaxies);

            Console.WriteLine(String.Format("The sum of shortest paths is {0}", sum));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            List<(long, long)> galaxies = ParseAndExpandGalaxy(instructions, 1000000);
            long sum = ShortestPathCalculator.CalculateSumOfShortestPaths(galaxies);

            Console.WriteLine(String.Format("The sum of shortest paths is {0}", sum));
        }
        public static void Main(string[] args)
        {
            string path = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\";
            string day = "Day 11 - Astronomy";

            string samplePath = path + day + @"\Sample.txt";
            string samplePath2 = path + day + @"\Sample2.txt";
            string fullPath = path + day + @"\Full.txt";
            string[] instructionsSample = System.IO.File.ReadAllLines(samplePath);
            string[] instructionsFull = System.IO.File.ReadAllLines(fullPath);
            Part1Solution(instructionsFull);
            Part2Solution(instructionsFull);
        }
    }
}


