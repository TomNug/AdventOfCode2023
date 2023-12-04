using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day4
{
    public class ScratchCard
    {
        public int Number { get; set; }
        public HashSet<int> WinningNumbers { get; set; }
        public HashSet<int> Numbers { get; set; }
        public ScratchCard(string input)
        {
            string scratchCardPattern = @"Card\s+(\d+): ((\s*(\d{1,2}))+) \| ((\s*(\d{1,2}))+)";
            Match match = Regex.Match(input, scratchCardPattern);
            Number = int.Parse(match.Groups[1].Value);
            WinningNumbers = new HashSet<int>(ExtractDigits(match.Groups[2].Value));
            Numbers = new HashSet<int>(ExtractDigits(match.Groups[5].Value));
        }

        static List<int> ExtractDigits(string input)
        {
            string digitPattern = @"(\d{1,2})";
            MatchCollection matches = Regex.Matches(input, digitPattern);
            List<int> result = new List<int>();
            foreach (Match match in matches)
                result.Add(int.Parse(match.Value));
            return result;
        }

        public int GetPoints()
        {
            HashSet<int> winners = new HashSet<int>(Numbers);
            winners.IntersectWith(WinningNumbers);
            return winners.Count > 0 ? Convert.ToInt32(Math.Pow(2,winners.Count - 1)) : 0;
        }

        public int GetNumMatches()
        {
            HashSet<int> winners = new HashSet<int>(Numbers);
            winners.IntersectWith(WinningNumbers);
            return winners.Count;
        }
    }
}
