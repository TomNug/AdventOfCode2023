using System.Text.RegularExpressions;

namespace Day6
{
   public class Day6
    {
        public static List<Race> ParseRaces(string[] instructions)
        {
            string timeString = instructions[0];
            string distanceString = instructions[1];

            string pattern = @".+:( +(\d+))+";
            Match matchTimes = Regex.Match(timeString, pattern);
            Match matchDistances = Regex.Match(distanceString, pattern);

            List<Race> races = new List<Race>();

            // Make each race
            for (int i=0; i<matchTimes.Groups.Count; i++)
            {
                races.Add(new Race(int.Parse(matchTimes.Groups[1].Captures[i].Value),
                    int.Parse(matchDistances.Groups[1].Captures[i].Value)));
            }
            return races;
        }

         public static void Part1Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 1 %%%");
            List<Race> races = ParseRaces(instructions);
            Console.WriteLine(String.Format("The lowest location is {0}", 5));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            Console.WriteLine(String.Format("The lowest location is {0}", 5));
        }
        public static void Main(string[] args)
        {


            string samplePath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 6 - Toy Races\Sample.txt";
            string fullPath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 6 - Toy Races\Full.txt";
            string[] instructions = System.IO.File.ReadAllLines(samplePath);
            Part1Solution(instructions);
            Part2Solution(instructions);
        }
    }
}


