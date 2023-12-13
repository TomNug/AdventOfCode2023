using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day12
{
    public class HotSpring
    {
        public string conditionReport { get; set; }
        public List<int> uncertainIndices { get; set; }
        public List<int> groupsBrokenSprings { get; set; }
        public HotSpring(string conditionReport, List<int> uncertainIndices, List<int> groupsBrokenSprings)
        {
            this.conditionReport = conditionReport;
            this.uncertainIndices = uncertainIndices;
            this.groupsBrokenSprings = groupsBrokenSprings;
        }

        public bool ErrorCheckSpring(string potentialSpring)
        {
            List<int> hashGroupLengths = FindHashLengths(potentialSpring);

            for (int i = 0; i < hashGroupLengths.Count; i++)
            {
                if (hashGroupLengths[i] != groupsBrokenSprings[i])
                    return false;
            }
            return true;
        }

        static List<int> FindHashIndices(string input)
        {
            List<int> hashIndices = new List<int>();
            MatchCollection matches = Regex.Matches(input, "#");
            foreach (Match match in matches)
                hashIndices.Add(match.Index);
            return hashIndices;
        }

        static List<int> FindHashLengths(string input)
        {
            List<int> hashLengths = new List<int>();
            MatchCollection matches = Regex.Matches(input, "#+");
            foreach (Match match in matches)
                hashLengths.Add(match.Length);
            return hashLengths;
        }

        public int CountPermutations()
        {
            int validPermutationCount = 0;


            return validPermutationCount;
        }

        static List<string> GeneratePermutations(string input)
        {
            List<string> permutations = new List<string>();
            GeneratePermutationsRecursive(input.ToCharArray(), 0, permutations);
            return permutations;
        }

        static void GeneratePermutationsRecursive(char[] chars, int currentIndex, List<string> permutations)
        {
            if (currentIndex == chars.Length - 1)
            {
                permutations.Add(new string(chars));
                return;
            }

            chars[currentIndex] = '0';
            GeneratePermutationsRecursive(chars, currentIndex + 1, permutations);

            chars[currentIndex] = '1';
            GeneratePermutationsRecursive(chars, currentIndex + 1, permutations);
        }
    }

}
