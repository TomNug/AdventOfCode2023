using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Map
    {
        private int sourceRangeStart;
        private int sourceRangeEnd;
        private int destinationRangeStart;
        private int destinationRangeEnd;

        public Map(int destinationRangeStart, int sourceRangeStart, int rangeLength)
        {
            this.sourceRangeStart = sourceRangeStart;
            this.sourceRangeEnd = sourceRangeStart + rangeLength - 1;
            this.destinationRangeStart = destinationRangeStart;
            this.destinationRangeEnd = destinationRangeStart + rangeLength - 1;
        }

        public int MapValue(int val)
        {
            if (val >= sourceRangeStart && val <= sourceRangeEnd)
                return destinationRangeStart + (val - sourceRangeStart);
            return val;
        }

        public bool CanMap(int val)
        {
            if (val >= sourceRangeStart && val <= sourceRangeEnd)
                return true;
            return false;
        }
    }
}
