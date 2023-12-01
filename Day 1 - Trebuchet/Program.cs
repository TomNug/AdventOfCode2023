// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

public class Program
{
    public static void main 
}


string testPath = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\Day 1 - Trebuchet\Test.txt";
string[] instructions = System.IO.File.ReadAllLines(testPath);

foreach (string instruction in instructions)
{
    string resultString = Regex.Match(instruction, @"\d+").Value;
    Console.WriteLine(resultString);
}
