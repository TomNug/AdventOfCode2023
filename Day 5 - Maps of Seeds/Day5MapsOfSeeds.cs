﻿using System.Text.RegularExpressions;
using Day4;

namespace Day5
{
    public class Day5MapsOfSeeds
    {
        private static List<ConversionMap> conversions = new List<ConversionMap>();
        // Used in part 1
        private static List<long> seeds = new List<long>();

        // Used in part 2
        private static HashSet<long> seedsHashSet = new HashSet<long>();
        private static List<(long, long)> seedsFromTo = new List<(long, long)> ();


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
        
        
        
        public static void ProcessSeeds()
        {
            // Treat seeds one at a time.
            // Store the result so we don't need to revist that number
            Dictionary<long, long> megaMap = new Dictionary<long, long>();
        
            // For each seed range
            foreach((long, long) fromTo in seedsFromTo)
            {
                // For each seed
                for (long i = fromTo.Item1; i<fromTo.Item2; i++)
                {
                    long seedResult = i;
                    // for each step in the conversions
                    foreach (ConversionMap conversion in conversions)
                    {
                        seedResult = conversion.Map(seedResult);
                    }
                    megaMap.Add(i, seedResult);
                }
            }
            int x = 5;
            
        }

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
            //List<ScratchCard> cards = new List<ScratchCard>();
            Console.WriteLine("\n%%% Part 1 %%%");
            ParseMaps(instructions);
            ProcessSeedsForPart1();
            Console.WriteLine(String.Format("The lowest location is {0}", seeds.Min()));
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


