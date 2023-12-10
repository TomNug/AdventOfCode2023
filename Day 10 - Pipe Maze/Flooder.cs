using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class Flooder
    {
        public static char[,] grid;
        public static void SetGrid(char[,] setGrid)
        {
            grid = setGrid;
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
            bool[,] visited = new bool[grid.GetLength(0), grid.GetLength(1)];

            // While queue has elements
            while (toVisit.Count > 0)
            {
                // Take first element
                currentNode = toVisit.Dequeue();

                // If unexplored
                if (!visited[currentNode.Item1, currentNode.Item2])
                {
                    // Find all adjacent nodes
                    List<(int, int)> potentials = FindAdjacentNodes(currentNode);

                    // Add adjacent nodes to queue
                    foreach((int,int) node in potentials)
                    {
                        if (!visited[node.Item1, node.Item2])
                            toVisit.Enqueue(node);
                    }

                    // If it's '.', mark it 'O'
                    if (grid[currentNode.Item1, currentNode.Item2] == '.')
                        grid[currentNode.Item1, currentNode.Item2] = 'O';

                    // Add to explored
                    visited[currentNode.Item1, currentNode.Item2] = true;
                }
            }
        }

        public static List<(int,int)> FindAdjacentNodes((int,int) node)
        {
            List<(int, int)> adjacentList = new List<(int, int)>();

            int row = node.Item1;
            int col = node.Item2;
            char c = grid[row, col];
            // Check up
            if (row > 0)
            {
                // Any symbol that would let water up
                if (c == '.' || c == '7' || c == '|' || c == 'F'|| c == 'J' || c == 'L') //  || c == 'S' 
                    adjacentList.Add((row-1, col));
            }

            // Check right
            if (col < grid.GetLength(1) - 1)
            {
                // Any symbol that would let water right
                if (c == '.' || c == '7' || c == 'F' || c == '-'|| c == 'J' || c == 'L') //  || c == 'S' 
                    adjacentList.Add((row, col + 1));
            }

            // Check left
            if (col > 0)
            {
                // Any symbol that would let water left
                if (c == '.' || c == '7' || c == 'F' || c == '-'|| c == 'J' || c == 'L') //  || c == 'S' 
                    adjacentList.Add((row, col - 1));
            }

            // Check down
            if (row < grid.GetLength(0) - 1)
            {
                // Any symbol that would let water down
                if (c == '.' || c == '7' || c == '|' || c == 'F'|| c == 'J' || c == 'L') //  || c == 'S' 
                    adjacentList.Add((row + 1, col));
            }

            return adjacentList;
        }


        // Iterates over the grid
        // Returns number of 'I's.
        public static int CountInsideTiles()
        {
            int numInsideTiles = 0;
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] == '.')
                    {
                        numInsideTiles++;
                    }
                }
            }
            return numInsideTiles;

        }

        public static int GetInsideTiles(char[,] grid, List<(int,int)> loop)
        {
            // Populate grid
            SetGrid(grid);

            // Flood
            FloodGrid();

            // Tally all Is
            int tiles = CountInsideTiles();

            return tiles;
        }
    }
}
