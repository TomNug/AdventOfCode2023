using System.Text.RegularExpressions;

namespace Day3
{
    public class Engine
    {
        public char[,] symbols { get; set; }
        // Highlights if a number is adjacent to a symbol
        private bool[,] included { get; set; }
        public Engine(char[,] grid)
        {
            symbols = grid;
            included = new bool[grid.GetLength(0), grid.GetLength(1)];
            for (int i = 0; i < symbols.GetLength(0); i++)
            {
                for (int j = 0; j<symbols.GetLength(1); j++)
                {
                    included[i, j] = false;
                }
            }
        }
        public void UpdateIncluded()
        {
            for (int i = 0; i < symbols.GetLength(0); i++)
            {
                for (int j = 0; j< symbols.GetLength(1); j++)
                {
                    if (symbols[i, j] != '.' && !char.IsDigit(symbols[i, j]))
                        SpreadIncluded(i, j);
                }
            }
        }

        public int SumIncluded()
        {
            return 5;
        }
        public void SpreadIncluded(int row, int col)
        {
            // NW
            included[Math.Max(row - 1, 0), Math.Max(col - 1,0)] = true;
            // N
            included[Math.Max(row - 1, 0), col] = true;
            // NE
            included[Math.Max(row - 1, 0), Math.Min(col + 1, included.GetLength(1)-1)] = true;
            // W
            included[row, Math.Max(col - 1, 0)] = true;
            // E
            included[row, Math.Min(col + 1, included.GetLength(1) - 1)] = true;
            // SW
            included[Math.Min(row + 1, included.GetLength(0) - 1), Math.Max(col - 1, 0)] = true;
            // S
            included[Math.Min(row + 1, included.GetLength(0)-1), col] = true;
            // SE
            included[Math.Min(row + 1, included.GetLength(0)-1), Math.Min(col + 1, included.GetLength(1)-1)] = true;
        }
        public bool IsIncluded(int row, int col)
        {
            return included[row, col];
        }
    }
    public class Gears
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
            engine.UpdateIncluded();

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


