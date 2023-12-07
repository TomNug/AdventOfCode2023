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

        public List<(long, long)> MapRange((long,long) range)
        {
            // Unmapped numbers
            // Either at the start and haven't been mapped yet
            // Or have been left behind on a pass through a map
            List<(long, long)> unmapped = new List<(long, long)>();

            // These are numbers which a map has taken and transformed
            List<(long,long)> mapped = new List<(long, long)> ();

            bool hasMapped = false;
            foreach (Map map in maps)
            {
                if (map.CanMapRange(range))
                {
                    //(List<(long,long)>, List<(long, long)>) mappedUnmapped = new map.MapRange(range);
                    //mapped.AddRange(mappedUnmapped.Item1);
                    //unmapped.AddRange(mappedUnmapped.Item2);
                    hasMapped = true;
                }
            }
            return unmapped; // TEMP PLEASE DO CHANGE
        }
    }
}
