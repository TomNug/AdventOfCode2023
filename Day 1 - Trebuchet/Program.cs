using System.Text.RegularExpressions;

public class Program
{
    public static int ExtractNumber(string original)
    {
        // Isolate first digit
        string patternFirst = @"\d+";
        // Isolate last digit
        string patternLast = @"(\d)[^\d]*$";
        // Combine
        char[] chars = { Regex.Match(original, patternFirst).Value[0], 
            Regex.Match(original, patternLast).Value[0] };
        // Return as int
        return Convert.ToInt32(new string(chars));
    }

    public static void Main(string[] args)
    {
        string testPath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 1 - Trebuchet\Test.txt";
        string fullPath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 1 - Trebuchet\Full.txt";
        string[] instructions = System.IO.File.ReadAllLines(fullPath);

        int sum = 0;
        foreach (string instruction in instructions)
        {
            sum+= ExtractNumber(instruction);
        }
        Console.WriteLine(String.Format("Final sum is {0}", sum));
    }
}



