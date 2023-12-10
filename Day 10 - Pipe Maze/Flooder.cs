using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class Flooder
    {
        public static char[,] expandedGrid;
        public static void CreateExpandedGrid(char[,] grid, List<(int,int)> loopElements)
        {
            expandedGrid = new char[grid.GetLength(0) * 3, grid.GetLength(1) * 3];

            // Make all Is
            for (int oldRow = 0; oldRow < grid.GetLength(0); oldRow++)
            {
                for (int oldCol = 0; oldCol < grid.GetLength(1); oldCol++)
                {
                    expandedGrid[oldRow * 3, oldCol * 3] = 'I';
                    expandedGrid[oldRow * 3, oldCol * 3 + 1] = 'I';
                    expandedGrid[oldRow * 3, oldCol * 3 + 2] = 'I';

                    expandedGrid[oldRow * 3 + 1, oldCol * 3] = 'I';
                    expandedGrid[oldRow * 3 + 1, oldCol * 3 + 1] = 'I';
                    expandedGrid[oldRow * 3 + 1, oldCol * 3 + 2] = 'I';

                    expandedGrid[oldRow * 3 + 2, oldCol * 3] = 'I';
                    expandedGrid[oldRow * 3 + 2, oldCol * 3 + 1] = 'I';
                    expandedGrid[oldRow * 3 + 2, oldCol * 3 + 2] = 'I';
                }
            }
            // Populate the loop
            foreach((int,int) element in loopElements)
            {
                int oldRow = element.Item1;
                int oldCol = element.Item2;
                char c = grid[oldRow, oldCol];
                if (c == '7')
                {
                    expandedGrid[oldRow * 3, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3, oldCol * 3 + 1] = 'O';
                    expandedGrid[oldRow * 3, oldCol * 3 + 2] = 'O';

                    expandedGrid[oldRow * 3 + 1, oldCol * 3] = 'x';
                    expandedGrid[oldRow * 3 + 1, oldCol * 3 + 1] = 'x';
                    expandedGrid[oldRow * 3 + 1, oldCol * 3 + 2] = 'O';

                    expandedGrid[oldRow * 3 + 2, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3 + 2, oldCol * 3 + 1] = 'x';
                    expandedGrid[oldRow * 3 + 2, oldCol * 3 + 2] = 'O';
                }
                else if (c == '|')
                {
                    expandedGrid[oldRow * 3, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3, oldCol * 3 + 1] = 'x';
                    expandedGrid[oldRow * 3, oldCol * 3 + 2] = 'O';

                    expandedGrid[oldRow * 3 + 1, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3 + 1, oldCol * 3 + 1] = 'x';
                    expandedGrid[oldRow * 3 + 1, oldCol * 3 + 2] = 'O';

                    expandedGrid[oldRow * 3 + 2, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3 + 2, oldCol * 3 + 1] = 'x';
                    expandedGrid[oldRow * 3 + 2, oldCol * 3 + 2] = 'O';
                }
                else if (c == 'F')
                {
                    expandedGrid[oldRow * 3, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3, oldCol * 3 + 1] = 'O';
                    expandedGrid[oldRow * 3, oldCol * 3 + 2] = 'O';

                    expandedGrid[oldRow * 3 + 1, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3 + 1, oldCol * 3 + 1] = 'x';
                    expandedGrid[oldRow * 3 + 1, oldCol * 3 + 2] = 'x';

                    expandedGrid[oldRow * 3 + 2, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3 + 2, oldCol * 3 + 1] = 'x';
                    expandedGrid[oldRow * 3 + 2, oldCol * 3 + 2] = 'O';
                }
                else if (c == '-')
                {
                    expandedGrid[oldRow * 3, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3, oldCol * 3 + 1] = 'O';
                    expandedGrid[oldRow * 3, oldCol * 3 + 2] = 'O';

                    expandedGrid[oldRow * 3 + 1, oldCol * 3] = 'x';
                    expandedGrid[oldRow * 3 + 1, oldCol * 3 + 1] = 'x';
                    expandedGrid[oldRow * 3 + 1, oldCol * 3 + 2] = 'x';

                    expandedGrid[oldRow * 3 + 2, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3 + 2, oldCol * 3 + 1] = 'O';
                    expandedGrid[oldRow * 3 + 2, oldCol * 3 + 2] = 'O';
                }
                else if (c == 'S')
                {
                    expandedGrid[oldRow * 3, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3, oldCol * 3 + 1] = 'x';
                    expandedGrid[oldRow * 3, oldCol * 3 + 2] = 'O';

                    expandedGrid[oldRow * 3 + 1, oldCol * 3] = 'x';
                    expandedGrid[oldRow * 3 + 1, oldCol * 3 + 1] = 'x';
                    expandedGrid[oldRow * 3 + 1, oldCol * 3 + 2] = 'x';

                    expandedGrid[oldRow * 3 + 2, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3 + 2, oldCol * 3 + 1] = 'x';
                    expandedGrid[oldRow * 3 + 2, oldCol * 3 + 2] = 'O';
                }
                else if (c == 'J')
                {
                    expandedGrid[oldRow * 3, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3, oldCol * 3 + 1] = 'x';
                    expandedGrid[oldRow * 3, oldCol * 3 + 2] = 'O';

                    expandedGrid[oldRow * 3 + 1, oldCol * 3] = 'x';
                    expandedGrid[oldRow * 3 + 1, oldCol * 3 + 1] = 'x';
                    expandedGrid[oldRow * 3 + 1, oldCol * 3 + 2] = 'O';

                    expandedGrid[oldRow * 3 + 2, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3 + 2, oldCol * 3 + 1] = 'O';
                    expandedGrid[oldRow * 3 + 2, oldCol * 3 + 2] = 'O';
                }
                else if (c == 'L')
                {
                    expandedGrid[oldRow * 3, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3, oldCol * 3 + 1] = 'x';
                    expandedGrid[oldRow * 3, oldCol * 3 + 2] = 'O';

                    expandedGrid[oldRow * 3 + 1, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3 + 1, oldCol * 3 + 1] = 'x';
                    expandedGrid[oldRow * 3 + 1, oldCol * 3 + 2] = 'x';

                    expandedGrid[oldRow * 3 + 2, oldCol * 3] = 'O';
                    expandedGrid[oldRow * 3 + 2, oldCol * 3 + 1] = 'O';
                    expandedGrid[oldRow * 3 + 2, oldCol * 3 + 2] = 'O';
                }
            }
        }

        public static void PrintExpandedGrid()
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < expandedGrid.GetLength(0); row++)
            {
                for (int col = 0; col < expandedGrid.GetLength(1); col++)
                {
                    sb.Append(expandedGrid[row, col]);
                }
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }
            Console.WriteLine();
        }
        // Starting at 0,0 (which is part of the padding), flood the map
        // Mark any open squares as O (outside) if we can reach them
        public static void FloodGrid()
        {
            // Set initial point to flood from
            (int, int) currentNode = (0, 0);

            // Queue to store potential nodes to visit
            Queue<(int, int)> toVisit = new Queue<(int, int)>();
            toVisit.Enqueue(currentNode);

            // grid of booleans representing explored
            bool[,] visited = new bool[expandedGrid.GetLength(0), expandedGrid.GetLength(1)];

            // While queue has elements
            while (toVisit.Count > 0)
            {
                // Take first element
                currentNode = toVisit.Dequeue();
                int row = currentNode.Item1;
                int col = currentNode.Item2;

                // If unexplored
                if (!visited[row,col])
                {
                    // Find all adjacent nodes
                    List<(int, int)> potentials = FindAdjacentNodes(row, col);

                    // Add adjacent nodes to queue
                    foreach ((int, int) node in potentials)
                    {
                        if (!visited[node.Item1, node.Item2])
                            toVisit.Enqueue(node);
                    }

                    // If it's 'I', mark it 'O'
                    if (expandedGrid[currentNode.Item1, currentNode.Item2] == 'I')
                        expandedGrid[currentNode.Item1, currentNode.Item2] = 'O';

                    // Add to explored
                    visited[currentNode.Item1, currentNode.Item2] = true;
                }
            }
        }

        public static List<(int,int)> FindAdjacentNodes(int row, int col)
        {
            List<(int, int)> adjacentList = new List<(int, int)>();
            char c = expandedGrid[row, col];

            // Check up
            if (row > 0)
                if (expandedGrid[row - 1, col] == 'I' || expandedGrid[row - 1, col] == 'O')
                    adjacentList.Add((row - 1, col));

            // Check right
            if (col < expandedGrid.GetLength(1) - 1)
            {
                if (expandedGrid[row, col + 1] == 'I' || expandedGrid[row, col + 1] == 'O')
                    adjacentList.Add((row, col + 1));
            }

            // Check left
            if (col > 0)
            {
                if (expandedGrid[row, col - 1] == 'I' || expandedGrid[row, col - 1] == 'O')
                    adjacentList.Add((row, col - 1));
            }

            // Check down
            if (row < expandedGrid.GetLength(0) - 1)
            {
                if (expandedGrid[row + 1, col] == 'I' || expandedGrid[row + 1, col] == 'O')
                    adjacentList.Add((row + 1, col));
            }

            return adjacentList;
        }


        // Iterates over the grid
        // Returns number of 'I's.
        public static int CountInsideTiles()
        {
            int numInsideTiles = 0;
            for (int row = 0; row < expandedGrid.GetLength(0); row++)
            {
                for (int col = 0; col < expandedGrid.GetLength(1); col++)
                {
                    if (expandedGrid[row, col] == 'I')
                    {
                        numInsideTiles++;
                    }
                }
            }
            return numInsideTiles / 9;
        }

        public static int GetInsideTiles(char[,] grid, List<(int,int)> loop)
        {
            // Populate grid
            CreateExpandedGrid(grid, loop);
            PrintExpandedGrid();
            // Flood
            FloodGrid();
            PrintExpandedGrid();
            // Tally all Is
            int tiles = CountInsideTiles();

            return tiles;
        }
    }
}
