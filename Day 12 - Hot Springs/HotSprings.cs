using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day12
{
    public class HotSprings
    {
        public List<HotSpring> springs { get; set; }
        public HotSprings(string[] instructions)
        {
            springs = new List<HotSpring>();
            // Parse instructions
            foreach(string instruction in instructions)
            {
                List<int> unknownIndices = findUnknownIndices(instruction);
                List<int> groupsBrokenSprings = findNumbers(instruction);
                string report = findReport(instruction);

                HotSpring spring = new HotSpring(report, unknownIndices, groupsBrokenSprings);
                springs.Add(spring);
            }
        }

        public int CountPermutationsOfAllSprings()
        {
            int count = 0;
            foreach (HotSpring spring in springs)
            {
                count += spring.CountPermutations();
            }
            return count;
        }
        public List<int> findUnknownIndices (string line)
        {
            List<int> indices = new List<int>();
            MatchCollection matches = Regex.Matches(line, @"\?");

            foreach (Match match in matches)
            {
                indices.Add(match.Index);
            }

            return indices;
        }


        public List<int> findNumbers(string input)
        {
            List<int> numbers = new List<int>();
            MatchCollection matches = Regex.Matches(input, @"\d+");

            foreach (Match match in matches)
            {
                numbers.Add(int.Parse(match.Value));
            }

            return numbers;
        }

        public string findReport(string input)
        {
            List<int> numbers = new List<int>();
            Match match = Regex.Match(input, @"((\.|\?|#)+)");

            return match.Groups[1].Value;
        }
    }
}
