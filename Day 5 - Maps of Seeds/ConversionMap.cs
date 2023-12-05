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
            List<(long,long)> returnVal = new List<(long, long)> ();
            bool hasMapped = false;
            foreach (Map map in maps)
            {
                if (map.CanMapRange(range))
                {
                    returnVal = map.MapRange(range);
                    hasMapped = true;
                }
            }
            if (!hasMapped)
                returnVal.Add(range);
            return returnVal;
        }
    }
}
