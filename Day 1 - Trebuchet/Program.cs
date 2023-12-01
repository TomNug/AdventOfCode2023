using System.Text.RegularExpressions;

public class Program
{
    public static int ExtractNumber(string original)
    {
        string patternFirst = @"\d+";
        char first = Regex.Match(original, patternFirst).Value[0];
        string patternLast = @"(\d)[^\d]*$";
        char last = Regex.Match(original, patternLast).Value[0];
        char[] chars = {first,last};
        string s = new string(chars);
        return Convert.ToInt32(s);
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



