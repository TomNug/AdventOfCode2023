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

            if (hashGroupLengths.Count == groupsBrokenSprings.Count)
            {
                for (int i = 0; i < hashGroupLengths.Count; i++)
                {
                    if (hashGroupLengths[i] != groupsBrokenSprings[i])
                        return false;
                }
                return true;
            }
            else
            {
                return false;
            }
            
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

            // Get the list of potential permutations of unknown characters
            List<string> permutationCharacters = GeneratePermutations(uncertainIndices.Count);

            // Assemble the string, inserting the permutation
            foreach(string perm in permutationCharacters)
            {
                string newString = CombineReportAndPermutaton(perm);
                if (ErrorCheckSpring(newString))
                {
                    validPermutationCount++;
                }
            }
            return validPermutationCount;
        }

        private string CombineReportAndPermutaton(string perm)
        {
            char[] newReport = conditionReport.ToCharArray();
            for (int i = 0; i < perm.Length; i++)
            {
                newReport[uncertainIndices[i]] = perm[i];
            }
            return new string(newReport);
        }
        public static List<string> GeneratePermutations(int numUnknowns)
        {
            char[] chars = new char[numUnknowns];
            List<string> permutations = new List<string>();
            GeneratePermutationsRecursive(chars, 0, permutations);
            return permutations;
        }

        static void GeneratePermutationsRecursive(char[] chars, int currentIndex, List<string> permutations)
        {
            if (currentIndex == chars.Length)
            {
                permutations.Add(new string(chars));
                return;
            }

            chars[currentIndex] = '.';
            GeneratePermutationsRecursive(chars, currentIndex + 1, permutations);

            chars[currentIndex] = '#';
            GeneratePermutationsRecursive(chars, currentIndex + 1, permutations);
        }
    }

}
