using System.Text;
using System.Text.RegularExpressions;

namespace Day11
{
    public class Program
    {
        public static (List<List<char>>, List<(int,int)>) ParseAndExpandGalaxy(string[] instructions)
        {
            bool[] rowHasGalaxy = new bool[instructions.Length];
            bool[] colHasGalaxy = new bool[instructions[0].Length];

            List<List<char>> grid = new List<List<char>>(); 
            for (int row = 0; row < instructions.Length; row++)
            {
                List<char> rowList = new List<char>();
                for (int col = 0; col < instructions[0].Length; col++)
                {
                    char c = instructions[row][col];
                    rowList.Add(c);
                    if (c == '#')
                    {
                        rowHasGalaxy[row] = true;
                        colHasGalaxy[col] = true;
                    }
                }
                grid.Add(rowList);
            }

            // Expand rows based on columns
            int numAddedColumns = 0;
            for (int col = 0; col < colHasGalaxy.Length; col++) 
            {
                if (!colHasGalaxy[col])
                {
                    foreach(List<char> rowList in grid)
                    {
                        rowList.Insert(col+ numAddedColumns, '.');
                        
                    }
                    numAddedColumns++;
                }
            }

            // Expand columns based on rows
            int rowExpandedLength = grid[0].Count;
            List<char> blankRow = new List<char>();
            for (int i = 0; i < rowExpandedLength; i++)
            {
                blankRow.Add('.');
            }
            int numAddedRows = 0;
            for (int row = 0; row < rowHasGalaxy.Length; row++)
            {
                if (!rowHasGalaxy[row])
                {
                    grid.Insert(row + numAddedRows, blankRow);
                    numAddedRows++;
                }
            }
            List<(int, int)> galaxies = new List<(int, int)>();
            for (int row = 0; row < grid.Count; row++)
            {
                for (int col = 0; col < grid[0].Count; col++)
                {
                    if (grid[row][col] == '#')
                    {
                        galaxies.Add((row, col));
                    }
                }
            }
            return (grid, galaxies);
        }
        public static void Part1Solution(string[] instructions)
        {

            Console.WriteLine("\n%%% Part 1 %%%");
            (List<List<char>>, List<(int,int)>) returnVal = ParseAndExpandGalaxy(instructions);
            List<List<char>> grid = returnVal.Item1;
            List<(int, int)> galaxies = returnVal.Item2;
            int sum = ShortestPathCalculator.CalculateSumOfShortestPaths(grid, galaxies);

            Console.WriteLine(String.Format("The sum of shortest paths is {0}", sum));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            
            Console.WriteLine(String.Format("The number of inside tiles is {0}", 5));
        }
        public static void Main(string[] args)
        {
            string path = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\";
            string day = "Day 11 - Astronomy";

            string samplePath = path + day + @"\Sample.txt";
            string samplePath2 = path + day + @"\Sample2.txt";
            string fullPath = path + day + @"\Full.txt";
            string[] instructionsSample = System.IO.File.ReadAllLines(samplePath);
            //string[] instructionsSample2 = System.IO.File.ReadAllLines(samplePath);
            string[] instructionsFull = System.IO.File.ReadAllLines(fullPath);
            Part1Solution(instructionsFull);
            Part2Solution(instructionsSample);
        }
    }
}


