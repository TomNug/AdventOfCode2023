using System.Text.RegularExpressions;

namespace Day2
{
    public class Cubes
    {
        public static Game ParseGame(string lineToRead)
        {
            // Read the game number
            string gamePattern = @"Game (\d+):";
            int gameId = Convert.ToInt32(Regex.Match(lineToRead, gamePattern).Groups[1].Value);
            // Remove Game and Number
            string remainingString = Regex.Replace(lineToRead, gamePattern, "");

            Game game = new Game(gameId);
            // Split the draws (;)
            string[] draws = remainingString.Split(';');
            foreach(string draw in draws)
            {
                int red = 0;
                int green = 0;
                int blue = 0;
                // Looking for "2 green", "4 red" etc.
                string numColPattern = @"(\d+) (red|green|blue)";
                MatchCollection matches = Regex.Matches(draw, numColPattern);
                foreach(Match match in matches)
                {
                    if (match.Groups[2].Value == "red")
                        red = Convert.ToInt32(match.Groups[1].Value);
                    else if (match.Groups[2].Value == "green")
                        green = Convert.ToInt32(match.Groups[1].Value);
                    else if (match.Groups[2].Value == "blue")
                        blue = Convert.ToInt32(match.Groups[1].Value);
                }
                game.AddCubeDraw(red, green, blue);
            }
            return game;
        }

        public static void Part1Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 1 %%%");
            int sum = 0;
            foreach (string instruction in instructions)
            {
                Game game = ParseGame(instruction);
                if (game.Possible())
                    sum += game.GameId;
            }
            Console.WriteLine(String.Format("Final sum of possible games is {0}", sum));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            int sum = 0;
            foreach (string instruction in instructions)
            {
                Game game = ParseGame(instruction);
                sum += game.GetPower();
            }
            Console.WriteLine(String.Format("Final sum of power is {0}", sum));
        }
        public static void Main(string[] args)
        {
            string testPath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 2 - Cube Game\Test.txt";
            string fullPath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 2 - Cube Game\Full.txt";
            string[] instructions = System.IO.File.ReadAllLines(fullPath);
            Part1Solution(instructions);
            Part2Solution(instructions);
        }
    }
}


