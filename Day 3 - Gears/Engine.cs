using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
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
                for (int j = 0; j < symbols.GetLength(1); j++)
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
                for (int j = 0; j < symbols.GetLength(1); j++)
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
                    if (!readingNumber && char.IsDigit(symbols[i, j]))
                    {
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
                    else if (readingNumber && char.IsDigit(symbols[i, j]))
                    {
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
            foreach (Gear gear in gears)
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
}
