using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
