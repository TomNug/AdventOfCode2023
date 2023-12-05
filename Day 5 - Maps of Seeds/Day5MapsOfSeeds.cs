using System.Text.RegularExpressions;
using Day4;

namespace Day5
{
    public class Day5MapsOfSeeds
    {
        private static List<List<Map>> allMaps = new List<List<Map>>();

        public static void ParseMaps(string[] input)
        {
            
            List<int> seeds = new List<int>();
            string patternSeeds = @"seeds:( (\d+))+";
            Match matchSeeds = Regex.Match(input[0], patternSeeds);
            if (matchSeeds.Success)
                seeds = Day4.ScratchCard.ExtractDigits(matchSeeds.Groups[0].Value);

            List<Map> maps = new List<Map>();
            string name = "";

            for (int i = 2; i < input.Length; i++)
            {
                string instruction = input[i];
                string patternName = @"(.+) map:";
                string patternMap = @"(\d+) (\d+) (\d+)";

                Match matchName = Regex.Match(instruction, patternName);
                Match matchMap = Regex.Match(instruction, patternMap);


                if (matchName.Success)
                    Console.WriteLine(matchName.Value);// name = matchName.Value;
                else if (matchMap.Success)
                {
                    Map map = new Map(int.Parse(matchMap.Groups[1].Value),
                        int.Parse(matchMap.Groups[2].Value),
                        int.Parse(matchMap.Groups[3].Value));
                    maps.Add(map);
                }
                else
                {
                    // Found a blank, reset for new map
                    allMaps.Add(maps);
                    maps = new List<Map>();

                }
                // End of file
                if (i + 1 == input.Length)
                    allMaps.Add(maps);
            }
            int x = 5;
        }
        public static void Part1Solution(string[] instructions)
        {
            //List<ScratchCard> cards = new List<ScratchCard>();
            Console.WriteLine("\n%%% Part 1 %%%");
            ParseMaps(instructions);
            int sumPoints = 0;
            Console.WriteLine(String.Format("The total points from the scratch cards is {0}", sumPoints));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            Console.WriteLine(String.Format("You end up with {0} scratchcards", 5));
        }
        public static void Main(string[] args)
        {
            string samplePath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 5 - Maps of Seeds\Sample.txt";
            string fullPath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 5 - Maps of Seeds\Full.txt";
            string[] instructions = System.IO.File.ReadAllLines(samplePath);
            Part1Solution(instructions);
            Part2Solution(instructions);
        }
    }
}


