using System.Text.RegularExpressions;

public class Program
{
    public static int ExtractNumber(string original)
    {
        // Isolate digit
        string pattern = @"\d";
        // Combine
        char[] chars = { Regex.Match(original, pattern).Value[0], 
            Regex.Match(original, pattern, RegexOptions.RightToLeft).Value[0] };
        // Return as int
        return Convert.ToInt32(new string(chars));
    }


    public static int ExtractNumberWords(string original)
    {
        // Dictionary to translate words into their values
        Dictionary<string, int> numberValues = new Dictionary<string, int>
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }

        };

        // Isolate "digit"
        string pattern = @"(\d|one|two|three|four|five|six|seven|eight|nine)";
        
        // Caculate integer values
        string firstMatch = Regex.Match(original, pattern).Value;
        int firstValue = Char.IsDigit(firstMatch[0]) ? Convert.ToInt32(firstMatch) : numberValues[firstMatch];

        string secondMatch = Regex.Match(original, pattern, RegexOptions.RightToLeft).Value;
        int lastValue = Char.IsDigit(secondMatch[0]) ? Convert.ToInt32(secondMatch) : numberValues[secondMatch];

        // Combine to two digit number
        return firstValue *10 + lastValue;
    }




    public static void Part1Solution(string[] instructions)
    {
        Console.WriteLine("\n%%% Part 1 %%%");
        int sum = 0;
        foreach (string instruction in instructions)
        {
            sum += ExtractNumber(instruction);
        }
        Console.WriteLine(String.Format("Final sum is {0}", sum));
    }

    public static void Part2Solution(string[] instructions)
    {
        Console.WriteLine("\n%%% Part 2 %%%");
        int sum = 0;
        foreach (string instruction in instructions)
        {
            sum += ExtractNumberWords(instruction);
        }
        Console.WriteLine(String.Format("Final sum is {0}", sum));
    }
    public static void Main(string[] args)
    {
        string testPath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 1 - Trebuchet\Test.txt";
        string testPath2 = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 1 - Trebuchet\Test2.txt";
        string fullPath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 1 - Trebuchet\Full.txt";
        string[] instructions1 = System.IO.File.ReadAllLines(fullPath);
        string[] instructions2 = System.IO.File.ReadAllLines(fullPath);
        Part1Solution(instructions1);
        Part2Solution(instructions2);
    }
}



