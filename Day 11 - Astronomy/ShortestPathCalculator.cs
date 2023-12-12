using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class ShortestPathCalculator
    {
        public static long CalculatePath((long, long) from, (long, long) to)
        {
            return Math.Abs(to.Item1-from.Item1) + Math.Abs(to.Item2-from.Item2);
        }
        public static long CalculateSumOfShortestPaths(List<(long, long)> galaxies)
        {
            long[,] shortestPaths = new long[galaxies.Count, galaxies.Count];
            for (int row = 0; row < shortestPaths.GetLength(0); row++)
            {
                for (int col = 0; col < shortestPaths.GetLength(1); col++)
                {
                    shortestPaths[row, col] = int.MaxValue;
                }
            }

            for (int from = 0; from < galaxies.Count; from++)
            {
                for (int to = 0; to < galaxies.Count; to++)
                {
                    if (from == to)
                    {
                        shortestPaths[from, to] = 0;
                    }
                    else
                    {
                        long newPath = CalculatePath(galaxies[from], galaxies[to]);
                        if (newPath < shortestPaths[from, to])
                        {
                            shortestPaths[from, to] = newPath;
                        }
                    }
                }
            }

            long sum = 0;
            foreach (long dist in shortestPaths)
                sum += dist; 
            return sum/2;
        }
    }
}
