using System.Text.RegularExpressions;
using Day4;

namespace Day5
{
    public class Day5MapsOfSeeds
    {
        private static List<ConversionMap> conversions = new List<ConversionMap>();
        // Used in part 1
        private static List<long> seeds = new List<long>();

        // Used in part 2
        private static List<(long, long)> seedsFromTo = new List<(long, long)> ();
        private static Dictionary<long, long> megaMap = new Dictionary<long, long>();

        public static void ProcessSeedsForPart1()
        {
            // for each step in the conversions
            foreach (ConversionMap conversion in conversions)
            {
                // Process each seed
                for (int seed = 0; seed < seeds.Count; seed++)
                {
                    seeds[seed] = conversion.Map(seeds[seed]);
                }
            }
        }
        
        // Used in testing to reset the static values
        public static void Reset()
        {
            seedsFromTo = new List<(long, long)>();
            conversions = new List<ConversionMap>();
        }
        
        public static long ProcessSeedsForPart2()
        {
            // The end result of each seed
            List<(long, long)> finalRanges = new List<(long, long)>();

            // To store the end result ranges from mapping 
            List<(long, long)> processedRanges = new List<(long, long)>();

            // For each seed range
            foreach ((long, long) range in seedsFromTo)
            {
                // Working list of ranges
                // Holds any processed ranged whilst still between maps
                List<(long, long)> startOfPassRanges = new List<(long, long)>();
                startOfPassRanges.Add(range);

                List<(long, long)> endOfPassRanges = new List<(long, long)>();

                // for each step in the conversions
                foreach (ConversionMap conversion in conversions)
                {
                    // For each range to consider
                    foreach((long, long) processingRange in startOfPassRanges)
                    { 
                        endOfPassRanges.AddRange(conversion.MapRange(processingRange));
                    }
                    startOfPassRanges = new List<(long,long)>(endOfPassRanges);
                    endOfPassRanges.Clear();
                }
                processedRanges.AddRange(startOfPassRanges);

            }

            // Find the lowest start of a range
            long lowest = long.MaxValue;
            foreach((long,long) range in processedRanges)
            {
                if (range.Item1 < lowest)
                    lowest = range.Item1;
            }
            return lowest;
            
        }

        // Reads the input and creates the maps
        public static void ParseMaps(string[] input)
        {
            string patternSeeds = @"seeds:( (\d+))+";
            Match matchSeeds = Regex.Match(input[0], patternSeeds);
            
            List<long> seedRanges = new List<long>();
            foreach (Capture capture in matchSeeds.Groups[2].Captures)
            {
                seeds.Add(long.Parse(capture.Value));
                seedRanges.Add(long.Parse(capture.Value));
            }
            for (int seedRange = 0; seedRange < seedRanges.Count; seedRange+=2)
            {
                long from = seedRanges[seedRange];
                long range = seedRanges[seedRange + 1];
                seedsFromTo.Add((from, from+range-1));
            }

            List<Map> maps = new List<Map>();
            string name = "";

            for (int i = 2; i < input.Length; i++)
            {
                string instruction = input[i];
                string patternName = @"(.+) map:";
                string patternMap = @"(\d+) (\d+) (\d+)";

                Match matchName = Regex.Match(instruction, patternName);
                Match matchMap = Regex.Match(instruction, patternMap);

                bool makeConversionMap = false;

                if (matchName.Success)
                    name = matchName.Groups[1].Value;
                else if (matchMap.Success)
                {
                    Map map = new Map(long.Parse(matchMap.Groups[1].Value),
                        long.Parse(matchMap.Groups[2].Value),
                        long.Parse(matchMap.Groups[3].Value));
                    maps.Add(map);
                }
                else
                    makeConversionMap = true;
                if (i + 1 == input.Length)
                    makeConversionMap = true;
                if (makeConversionMap)
                {
                    ConversionMap newConversionMap = new ConversionMap(maps, name);
                    conversions.Add(newConversionMap);
                    maps = new List<Map>();
                }
            }
            int x = 5;
        }
        public static void Part1Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 1 %%%");
            ParseMaps(instructions);
            ProcessSeedsForPart1();
            Console.WriteLine(String.Format("The lowest location is {0}", seeds.Min()));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            long lowest = ProcessSeedsForPart2();
            Console.WriteLine(String.Format("The lowest location is {0}", lowest));
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


