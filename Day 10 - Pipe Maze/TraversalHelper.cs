using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class TraversalHelper
    {
        /// <summary>
        /// Finds the next step in the look
        /// </summary>
        /// <param name="previous">The previous step in the maze, so we don't go backwards</param>
        /// <param name="current">Current place in the maze</param>
        /// <param name="grid">Maze</param>
        /// <returns></returns>
        public static (int,int) NextStepThroughMaze((int,int) previous, (int,int) current, char[,] grid)
        {
            ((int, int), (int, int)) adjacentPositions = FindAdjacentPositions(current, grid);

            if (adjacentPositions.Item1 == previous)
                return adjacentPositions.Item2;
            else
                return adjacentPositions.Item1;
        }
        /// <summary>
        /// From a point on the grid, finds the two positions you can move to
        /// </summary>
        /// <param name="current">Current position</param>
        /// <param name="grid">Grid</param>
        /// <returns></returns>
        public static ((int, int), (int, int)) FindAdjacentPositions((int,int) current, char[,] grid)
        {
            List<(int, int)> found = new List<(int, int)>();

            int currentRow = current.Item1;
            int currentCol = current.Item2;
            // Check above
            char potential = grid[currentRow - 1, currentCol];
            if (potential == '7' || potential == '|' || potential == 'F')
            {
                found.Add((currentRow - 1, currentCol));
            }
            // Check right
            potential = grid[currentRow, currentCol+1];
            if (potential == 'J' || potential == '-' || potential == '7')
            {
                found.Add((currentRow, currentCol + 1));
            }
            
            if (found.Count < 2)
            {
                // Check left
                potential = grid[currentRow, currentCol - 1];
                if (potential == 'L' || potential == '-' || potential == 'F')
                {
                    found.Add((currentRow, currentCol - 1));
                }
                if (found.Count < 2)
                {
                    // Check down
                    potential = grid[currentRow + 1, currentCol];
                    if (potential == 'J' || potential == '|' || potential == 'L')
                    {
                        found.Add((currentRow + 1, currentCol));
                    }
                }
            }

            ((int, int), (int, int)) returnVal = (found[0], found[1]);
            return returnVal;
        }
    }
}
