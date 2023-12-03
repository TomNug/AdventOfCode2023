using System.Text;
using System.Text.RegularExpressions;

namespace Day3
{
    public class Gear
    {
        public List<int> adjacentNumbers { get; set; }
        public int row { get; set; }
        public int col { get; set; }
        public Gear(int newRow, int newCol)
        {
            row = newRow;
            col = newCol;
            adjacentNumbers = new List<int>();
        }
        public Gear(int newRow, int newCol, List<int> newAdjacentNumbers)
        {
            row = newRow;
            col = newCol;
            adjacentNumbers = newAdjacentNumbers;
        }
        public void AddAdjacent(int number)
        {
            adjacentNumbers.Add(number);
        }
        // Tests if a point is adjacent to this gear
        public bool AdjacencyTest(int testRow, int testCol)
        {
            return (Math.Abs(testRow - row) <= 1 && Math.Abs(testCol - col) <= 1);
        }
        public int GetGearRatio()
        {
            int product = 1;
            if (adjacentNumbers.Count == 2)
            {
                foreach (int num in adjacentNumbers)
                    product *= num;
            }
            return product > 1 ? product : 0;
        }
    }
    public class Engine
    {
        public char[,] symbols { get; set; }
        // Highlights if a number is adjacent to a symbol
        private bool[,] included { get; set; }
        private bool[,] adjacentToGear { get; set; }
        public List<Gear> gears { get; set; }
        // Determines which numbers are gears
        private bool[,] potentialPartOfGear { get; set; }

        public Engine(char[,] grid)
        {
            symbols = grid;
            included = new bool[grid.GetLength(0), grid.GetLength(1)];
            adjacentToGear = new bool[grid.GetLength(0), grid.GetLength(1)];
            for (int i = 0; i < symbols.GetLength(0); i++)
            {
                for (int j = 0; j<symbols.GetLength(1); j++)
                {
                    included[i, j] = false;
                    adjacentToGear[i, j] = false;
                }
            }
            gears = new List<Gear>();
        }
        public void UpdateFlags()
        {
            for (int i = 0; i < symbols.GetLength(0); i++)
            {
                for (int j = 0; j< symbols.GetLength(1); j++)
                {
                    if (symbols[i, j] != '.' && !char.IsDigit(symbols[i, j]))
                        SpreadProperty(included, i, j);
                    if (symbols[i, j] == '*')
                        SpreadProperty(adjacentToGear, i, j);
                }
            }
        }
        public void FindGears()
        {
            for (int i = 0; i < symbols.GetLength(0); i++)
            {
                for (int j = 0; j < symbols.GetLength(1); j++)
                {
                    if (symbols[i, j] == '*')
                    {
                        Gear newGear = new Gear(i, j);
                        gears.Add(newGear);
                        SpreadProperty(adjacentToGear, i, j);
                    }
                }
            }
        }
        public int CalcSumIncluded()
        {
            int sum = 0;

            for (int i = 0; i < symbols.GetLength(0); i++)
            {
                bool readingNumber = false;
                bool numberIsIncluded = false;
                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < symbols.GetLength(1); j++)
                {
                    // Finding the start of a number
                    if (!readingNumber && char.IsDigit(symbols[i, j])){
                        readingNumber = true;
                        sb.Append(symbols[i, j]);
                    }
                    // Was reading a number, now ended
                    else if (readingNumber && !char.IsDigit(symbols[i, j]))
                    {
                        readingNumber = false;
                        if (numberIsIncluded && sb.Length > 0)
                        {
                            numberIsIncluded = false;
                            sum += int.Parse(sb.ToString());
                        }
                        sb.Clear();
                    }
                    // Continuing to read a number
                    else if (readingNumber && char.IsDigit(symbols[i, j])){
                        sb.Append(symbols[i, j]);
                    }
                    
                    if (readingNumber && included[i, j])
                        numberIsIncluded = true;
                    // End of row
                    if (j == symbols.GetLength(1) - 1)
                    {
                        if (numberIsIncluded && sb.Length > 0)
                            sum += int.Parse(sb.ToString());
                        sb.Clear();
                    }
                }
            }
            return sum;
        }
        
        public void CalcGearAdjacentNumbers()
        {
            foreach(Gear gear in gears)
            {
                int minRow = Math.Max(gear.row - 1, 0);
                int maxRow = Math.Min(gear.row + 1, symbols.GetLength(0) - 1);
                // Only need to scan line above and below
                for (int i = minRow; i <= maxRow; i++)
                {
                    bool readingNumber = false;
                    bool numberIsAdjacent = false;
                    StringBuilder sb = new StringBuilder();

                    for (int j = 0; j < symbols.GetLength(1); j++)
                    {
                        

                        // Finding the start of a number
                        if (!readingNumber && char.IsDigit(symbols[i, j]))
                        {
                            if (gear.AdjacencyTest(i, j))
                                numberIsAdjacent = true;
                            readingNumber = true;
                            sb.Append(symbols[i, j]);
                        }
                        // Was reading a number, now ended
                        else if (readingNumber && !char.IsDigit(symbols[i, j]))
                        {
                            readingNumber = false;
                            if (numberIsAdjacent && sb.Length > 0)
                            {
                                numberIsAdjacent = false;
                                gear.AddAdjacent(int.Parse(sb.ToString()));
                            }
                            sb.Clear();
                        }
                        // Continuing to read a number
                        else if (readingNumber && char.IsDigit(symbols[i, j]))
                        {
                            if (gear.AdjacencyTest(i, j))
                                numberIsAdjacent = true;
                            sb.Append(symbols[i, j]);
                        }
                        // End of row
                        if (j == symbols.GetLength(1) - 1)
                        {
                            if (numberIsAdjacent && sb.Length > 0)
                                gear.AddAdjacent(int.Parse(sb.ToString()));
                            sb.Clear();
                        }
                    }
                }
            }

        }
        public void SpreadProperty(bool[,] array, int row, int col)
        {
            int numRows = array.GetLength(0);
            int numCols = array.GetLength(1);

            SetFlag(array, row - 1, col - 1);
            SetFlag(array, row - 1, col);
            SetFlag(array, row - 1, col + 1);

            SetFlag(array, row, col - 1);
            SetFlag(array, row, col + 1);

            SetFlag(array, row + 1, col - 1);
            SetFlag(array, row + 1, col);
            SetFlag(array, row + 1, col + 1);
        }
        private void SetFlag(bool[,] array, int row, int col)
        {
            int numRows = array.GetLength(0);
            int numCols = array.GetLength(1);

            int validRow = Math.Max(0, Math.Min(row, numRows - 1));
            int validCol = Math.Max(0, Math.Min(col, numCols - 1));

            array[validRow, validCol] = true;
        }
        public bool IsIncluded(int row, int col)
        {
            return included[row, col];
        }
        public bool IsAdjacentToGear(int row, int col)
        {
            return adjacentToGear[row, col];
        }
        public int GetSumOfAllGearRatios()
        {
            int sumGearRatios = 0;
            foreach (Gear gear in gears)
                sumGearRatios += gear.GetGearRatio();
            return sumGearRatios;
        }
    }
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


