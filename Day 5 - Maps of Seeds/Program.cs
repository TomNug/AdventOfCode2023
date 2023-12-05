namespace Day5
{
    public class Day5MapsOfSeeds
    {
        public static void Part1Solution(string[] instructions)
        {
            //List<ScratchCard> cards = new List<ScratchCard>();
            Console.WriteLine("\n%%% Part 1 %%%");
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
            string[] instructions = System.IO.File.ReadAllLines(fullPath);
            Part1Solution(instructions);
            Part2Solution(instructions);
        }
    }
}


