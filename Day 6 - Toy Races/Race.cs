using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    public class Race
    {
        public int time { get; set; }
        public long distance { get; set; }
        public Race(int time, long distance)
        {
            this.time = time;
            this.distance = distance;
        }
        
        static int RoundUpAndIncremementIfInt(double num)
        {
            if (num % 1 == 0) 
                return Convert.ToInt32(Math.Ceiling(num) + 1);
            else
                return Convert.ToInt32(Math.Ceiling(num));
        }
        static int RoundDownAndDecremementIfInt(double num)
        {
            if (num % 1 == 0)
                return Convert.ToInt32(Math.Floor(num) - 1);
            else
                return Convert.ToInt32(Math.Floor(num));
        }
        public int CalculateNumberOfWinners()
        {
            int a = -1;
            int b = time;
            long c = -distance;
            double x1 = (-b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);
            double x2 = (-b - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c)) / (2 * a);

            int y1 = RoundUpAndIncremementIfInt(x1);
            int y2 = RoundDownAndDecremementIfInt(x2);

            return y2 - y1 + 1;
        }
    }

    
}
