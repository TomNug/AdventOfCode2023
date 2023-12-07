using System.Text;
using System.Text.RegularExpressions;

namespace Day6
{
   public class Day6
    {
        public static List<Race> ParseRaces(string[] instructions, bool part1=true)
        {
            string timeString = instructions[0];
            string distanceString = instructions[1];

            string pattern = @".+:(\s*\d)+";
            if (part1)
                pattern = @".+:(?:\s+(\d+))+";

            Match matchTimes = Regex.Match(timeString, pattern);
            Match matchDistances = Regex.Match(distanceString, pattern);

            List<Race> races = new List<Race>();

            // Part 1
            if (part1)
            {
                // Make each race
                for (int i = 0; i < matchTimes.Groups[1].Captures.Count; i++)
                {
                    races.Add(new Race(int.Parse(matchTimes.Groups[1].Captures[i].Value),
                        int.Parse(matchDistances.Groups[1].Captures[i].Value)));
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                // Assemble the time
                for (int i = 0; i < matchTimes.Groups[1].Captures.Count; i++)
                    sb.Append(matchTimes.Groups[1].Captures[i].Value.Trim());
                int time = Convert.ToInt32(sb.ToString());
                sb.Clear();

                // Assemble the distance
                for (int i = 0; i < matchDistances.Groups[1].Captures.Count; i++)
                    sb.Append(matchDistances.Groups[1].Captures[i].Value.Trim());
                long distance = Convert.ToInt64(sb.ToString());

                races.Add(new Race(time, distance));
            }
            return races;
        }

        public static int CalculateProductOfErrorMargins(List<Race> races)
        {
            int product = 1;
            foreach (Race race in races)
                product *= race.CalculateNumberOfWinners();
            return product;
        }
         public static void Part1Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 1 %%%");
            List<Race> races = ParseRaces(instructions);
            int productOfErrorMargins = CalculateProductOfErrorMargins(races);
            Console.WriteLine(String.Format("The product of the error margins is {0}", productOfErrorMargins));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            List<Race> races = ParseRaces(instructions, false);
            int productOfErrorMargins = CalculateProductOfErrorMargins(races);
            Console.WriteLine(String.Format("The product of the error margins is {0}", productOfErrorMargins));
        }
        public static void Main(string[] args)
        {


            string samplePath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 6 - Toy Races\Sample.txt";
            string fullPath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 6 - Toy Races\Full.txt";
            string[] instructions = System.IO.File.ReadAllLines(fullPath);
            Part1Solution(instructions);
            Part2Solution(instructions);
        }
    }
}


