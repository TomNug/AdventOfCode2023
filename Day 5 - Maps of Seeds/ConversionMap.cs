using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class ConversionMap
    {
        private List<Map> maps;
        public string name { get; set; }
        public ConversionMap(List<Map> maps, string name)
        {
            this.maps = maps;
            this.name = name;
        }
        public long Map(long seed)
        {
            foreach(Map map in maps)
            {
                if (map.CanMap(seed))
                {
                    return map.MapValue(seed);
                }
            }
            return seed;
        }

        // Takes a range
        // Applies each map to the range
        // Returns the final list of ranges after applying maps
        public List<(long, long)> MapRange((long,long) range)
        {
            // Unmapped numbers
            // Either at the start and haven't been mapped yet
            // Or have been left behind on a pass through a map
            // Passed forward to the next map
            List<(long, long)> unmapped = new List<(long,long)> { range };

            // These are numbers which a map has taken and transformed
            // Will become the return value
            List<(long,long)> mapped = new List<(long, long)> ();

            // Applying each map in turn
            // Anything mapped goes into mapped
            // Anything unmapped goes into unmapped
            foreach (Map map in maps)
            {
                // Check each unmapped value
                // If it can be mapped, map it

                // Keeps track of ranges which have been mapped
                // So they can be removed after iterating through unmapped
                List<(long, long)> mappedRangesToDelete = new List<(long, long)>();

                // This tracks the unmapped ranges from the current map
                // Curate first, then add to overall pool
                List<(long, long)> unmappedToAdd = new List<(long, long)> {  };


                // Foreach unmapped range
                foreach ((long,long) unmappedRange in unmapped)
                {
                    if (map.CanMapRange(unmappedRange))
                    {
                        ((long, long), List<(long, long)>) mappedUnmapped = map.MapRangeReturningMappedUnmapped(unmappedRange);
                        // Add the mapped range to the list
                        mapped.Add(mappedUnmapped.Item1);
                        // Determine unmapped ranges to be passed onwards to the next iteration's map
                        unmappedToAdd.AddRange(mappedUnmapped.Item2);
                        // It has been mapped, so remove the current range
                        mappedRangesToDelete.Add(unmappedRange);
                    }
                }

                // Remove any mapped ranges from the unmapped ranges
                foreach((long,long) rangeToRemove in mappedRangesToDelete)
                {
                    unmapped.Remove(rangeToRemove);
                }
                // Add the map's unmapped ranges to the list for the next iteration
                unmapped.AddRange(unmappedToAdd);
            }

            // If we have mapped, combine the lists
            if (mapped.Count >= 0)
                mapped.AddRange(unmapped);

            // If we haven't mapped, need to return the initial range
            else
                mapped.Add(range);

            return mapped;
        }
    }
}
