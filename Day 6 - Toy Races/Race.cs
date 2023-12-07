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
        public int distance { get; set; }
        public Race(int time, int distance)
        {
            this.time = time;
            this.distance = distance;
        }
    }
}
