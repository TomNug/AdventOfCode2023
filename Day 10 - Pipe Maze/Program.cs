using System.Text;
using System.Text.RegularExpressions;

namespace Day10
{
    public class Program
    {
        public static (char[,],(int,int)) ParseForGridAndStart(string[] instructions)
        {
            (int, int) start = (-1, -1);
            int rows = instructions.Length + 2;
            int cols = instructions[0].Length + 2;
            char[,] grid = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                // First or last row, make all '.'
                if (row == 0 || row == rows - 1)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        grid[row, col] = '.';
                    }
                }
                else
                {
                    grid[row, 0] = '.';
                    grid[row, cols-1] = '.';
                }
                
            }

            for (int i = 0; i < instructions.Length; i++)
                for (int j = 0; j < instructions[0].Length; j++)
                {
                    grid[i + 1, j + 1] = (char)(instructions[i][j]);
                    if (instructions[i][j] == 'S')
                        start = (i+1, j+1);
                }
                    
            return (grid, start);
        }

        
        public static void Part1Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 1 %%%");
            (char[,], (int,int)) gridStart = ParseForGridAndStart(instructions);
            char[,] grid = gridStart.Item1;
            (int, int) start = gridStart.Item2;
            TraversalHelper helper = new TraversalHelper();
            helper.SetGrid(grid);
            int maxSteps = helper.FindFarthestPointInMaze(start);
            Console.WriteLine(String.Format("The farthest point is {0} steps away", maxSteps));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            (char[,], (int, int)) gridStart = ParseForGridAndStart(instructions);
            char[,] grid = gridStart.Item1;
            (int, int) start = gridStart.Item2;
            TraversalHelper helper = new TraversalHelper();
            helper.SetGrid(grid);
            int maxSteps = helper.FindFarthestPointInMaze(start);
            HashSet<(int, int)> pointsOnLoop = helper.pointsOnLoop;
            int numTiles = Flooder.GetInsideTiles(grid, pointsOnLoop.ToList<(int,int)>());
            Console.WriteLine(String.Format("The number of inside tiles is {0}", numTiles));
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
            Part1Solution(instructionsFull);
            Part2Solution(instructionsSample);
        }
    }
}


