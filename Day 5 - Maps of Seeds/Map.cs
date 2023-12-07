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

        // Used in part 1
        public long MapValue(long val)
        {
            if (val >= sourceRangeStart && val <= sourceRangeEnd)
                return destinationRangeStart + (val - sourceRangeStart);
            return val;
        }

        // Returns a list of unmapped ranges, and a new range representing mapped numbers
        // Should check with CanMap first
        public ((long, long), List<(long, long)>) MapRangeReturningMappedUnmapped((long, long) inputRange)
        {
            long inputLow = inputRange.Item1;
            long inputHigh = inputRange.Item2;

            // There'll be at max one range that is mapped
            (long, long) mappedNumbers;
            // There'll be at max two ranges that are untouched (above and below)
            List<(long, long)> unmappedNumbers = new List<(long, long)>();

            //      1   2   3   4   5   6   7
            //              3   4   5
            //
            // Find inputRange that's below range
            if (inputLow < sourceRangeStart)
            {
                // A portion of input range is below the range
                unmappedNumbers.Add((inputLow, Math.Min(inputHigh, sourceRangeStart - 1)));
            }
            // Find inputRange that's in the range
            long newLow = (Math.Max(inputLow, sourceRangeStart) - sourceRangeStart) + destinationRangeStart;
            long newHigh = (Math.Min(inputHigh, sourceRangeEnd) - sourceRangeStart) + destinationRangeStart;
            mappedNumbers = (newLow, newHigh);
            
            // Find inputRange that's above range
            if (inputHigh > sourceRangeEnd)
            {
                // A portion of input range is above the range
                unmappedNumbers.Add(((Math.Max(sourceRangeEnd + 1, inputLow), inputHigh)));
            }
            return ((mappedNumbers, unmappedNumbers));
        }

        public bool CanMap(long val)
        {
            if (val >= sourceRangeStart && val <= sourceRangeEnd)
                return true;
            return false;
        }

        public bool CanMapRange((long, long) range)
        {
            long inputLow = range.Item1;
            long inputHigh = range.Item2;

            if (inputLow <= sourceRangeEnd && inputHigh >= sourceRangeStart)
                return true;
            return false;
        }

    }
}
