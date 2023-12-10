using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class TraversalHelper
    {
        public char[,] grid;
        public HashSet<(int, int)> pointsOnLoop = new HashSet<(int, int)>();

        public void SetGrid(char[,] setGrid)
        {
            grid = setGrid;
        }
        /// <summary>
        /// Finds the next step in the look
        /// </summary>
        /// <param name="previous">The previous step in the maze, so we don't go backwards</param>
        /// <param name="current">Current place in the maze</param>
        /// <returns></returns>
        public (int,int) NextStepThroughMaze((int,int) previous, (int,int) current)
        {
            ((int, int), (int, int)) adjacentPositions = FindAdjacentPositions(current);

            if (adjacentPositions.Item1 == previous)
                return adjacentPositions.Item2;
            else
                return adjacentPositions.Item1;
        }
        /// <summary>
        /// From a point on the grid, finds the two positions you can move to
        /// </summary>
        /// <param name="current">Current position</param>
        /// <returns></returns>
        public ((int, int), (int, int)) FindAdjacentPositions((int,int) current)
        {
            List<(int, int)> found = new List<(int, int)>();

            int currentRow = current.Item1;
            int currentCol = current.Item2;
            char currentChar = grid[currentRow, currentCol];

            // Can we connect above?
            if (currentChar == 'J' || currentChar == '|' || currentChar == 'L' || currentChar == 'S')
            {
                // Check above
                char potential = grid[currentRow - 1, currentCol];
                if (potential == '7' || potential == '|' || potential == 'F')
                {
                    found.Add((currentRow - 1, currentCol));
                }
            }

            // Can we connect right?
            if (currentChar == 'L' || currentChar == '-' || currentChar == 'F' || currentChar == 'S')
            {
                // Check right
                char potential = grid[currentRow, currentCol + 1];
                if (potential == 'J' || potential == '-' || potential == '7')
                {
                    found.Add((currentRow, currentCol + 1));
                }
            }

            // Can we connect left?
            if (currentChar == 'J' || currentChar == '-' || currentChar == '7' || currentChar == 'S')
            {
                // Check left
                char potential = grid[currentRow, currentCol - 1];
                if (potential == 'L' || potential == '-' || potential == 'F')
                {
                    found.Add((currentRow, currentCol - 1));
                }
            }

            // Can we connect down?
            if (currentChar == '7' || currentChar == '|' || currentChar == 'F' || currentChar == 'S')
            {
                // Check down
                char potential = grid[currentRow + 1, currentCol];
                if (potential == 'J' || potential == '|' || potential == 'L')
                {
                    found.Add((currentRow + 1, currentCol));
                }
            }

            if (found.Count < 2)
                return ((found[0], found[0]));
            else
                return (found[0], found[1]);
        }

        public int FindFarthestPointInMaze((int, int) start)
        {
            ((int, int), (int, int)) startOptions = FindAdjacentPositions(start);

            HashSet<(int, int)> pointsOnLoop = new HashSet<(int, int)>();

            (int, int) path1Current = startOptions.Item1;
            (int, int) path1Previous = start;
            List<(int, int)> path1 = new List<(int, int)> { path1Previous, path1Current };

            (int, int) path2Current = startOptions.Item2;
            (int, int) path2Previous = start;
            List<(int, int)> path2 = new List<(int, int)> { path2Previous, path2Current };

            int numSteps = 1;
            bool foundFarthest = false;
            while (!foundFarthest)
            {
                // Step paths
                (int, int) path1Next = NextStepThroughMaze(path1Previous, path1Current);
                path1.Add(path1Next);
                pointsOnLoop.Add(path1Next);
                (int, int) path2Next = NextStepThroughMaze(path2Previous, path2Current);
                path2.Add(path2Next);
                pointsOnLoop.Add(path2Next);
                numSteps++;

                if (path1.Contains(path2Next) || path2.Contains(path1Next))
                {
                    // Past the farthest point
                    return numSteps;
                }

                // Update state
                path1Previous = path1Current;
                path1Current = path1Next;                
                path2Previous = path2Current;
                path2Current = path2Next;
                
            }
            return -1;
        }


    }
}
