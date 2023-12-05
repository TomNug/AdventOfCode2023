using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class Map
    {
        private long sourceRangeStart;
        private long sourceRangeEnd;
        private long destinationRangeStart;
        private long destinationRangeEnd;

        public Map(long destinationRangeStart, long sourceRangeStart, long rangeLength)
        {
            this.sourceRangeStart = sourceRangeStart;
            this.sourceRangeEnd = sourceRangeStart + rangeLength - 1;
            this.destinationRangeStart = destinationRangeStart;
            this.destinationRangeEnd = destinationRangeStart + rangeLength - 1;
        }

        public long MapValue(long val)
        {
            if (val >= sourceRangeStart && val <= sourceRangeEnd)
                return destinationRangeStart + (val - sourceRangeStart);
            return val;
        }

        public bool CanMap(long val)
        {
            if (val >= sourceRangeStart && val <= sourceRangeEnd)
                return true;
            return false;
        }
    }
}
