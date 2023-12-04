

namespace Day4
{
    public class Day4ScratchCards
    {
        public static void Part1Solution(string[] instructions)
        {
            //List<ScratchCard> cards = new List<ScratchCard>();
            Console.WriteLine("\n%%% Part 1 %%%");
            int sumPoints = 0;
            foreach(string instruction in instructions)
            {
                ScratchCard newCard = new ScratchCard(instruction);
                //cards.Add(newCard);
                sumPoints += newCard.Points;
                int x = 5;
            }
            Console.WriteLine(String.Format("The total points from the scratch cards is {0}", sumPoints));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            ScratchCardPool pool = new ScratchCardPool(instructions);
            pool.ScoreAllCards();
            var numCards = pool.CountNumCards();
            Console.WriteLine(String.Format("You end up with {0} scratchcards", numCards));
        }
        public static void Main(string[] args)
        {
            string samplePath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 4 - Scratch Cards\Sample.txt";
            string fullPath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 4 - Scratch Cards\Full.txt";
            string[] instructions = System.IO.File.ReadAllLines(fullPath);
            Part1Solution(instructions);
            Part2Solution(instructions);
        }
    }
}


