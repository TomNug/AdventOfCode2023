using System.Text.RegularExpressions;

namespace Day2
{
    public class Game
    {
        public int GameId { get; private set; }
        // Highest value encountered of Red Green Blue
        public int MaxR { get; private set; }
        public int MaxG { get; private set; }
        public int MaxB { get; private set; }

        // Maximum allowed values for a game to be 'possible'
        private int AllowedRed = 12;
        private int AllowedGreen = 13;
        private int AllowedBlue = 14;
        public Game(int id)
        {
            GameId = id;
        }
        public Game(int id, int red, int green, int blue)
        {
            GameId = id;
            MaxR = red; 
            MaxG = green;
            MaxB = blue;
        }
        // Adds a given cube draw to the game knowledge
        public void AddCubeDraw(int red, int green, int blue)
        {
            // Update maximums
            if (red > MaxR)
                MaxR = red;
            if (green > MaxG)
                MaxG = green;
            if (blue > MaxB)
                MaxB = blue;
        }

        public bool Possible()
        {
            return (MaxR <= AllowedRed && MaxG <= AllowedGreen && MaxB <= AllowedBlue);
        }

        public int GetPower()
        {
            return MaxR * MaxG * MaxB;
        }
    }
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


