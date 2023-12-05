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
        public int Map(int seed)
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
    }
}
