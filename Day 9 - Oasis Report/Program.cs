using System.Text;
using System.Text.RegularExpressions;

namespace Day9
{
    public class Program
    {
        public static bool AllZeroes(List<int> ints)
        {
            foreach (int num in ints)
                if (num != 0)
                    return false;
            return true;
        }

        public static int CalculateModifierFromStack(Stack<int> stack, bool findingNumberOnEnd)
        {
            int num = stack.Pop();
            if (findingNumberOnEnd)
            {
                while (stack.Count > 0)
                    num += stack.Pop();

                return num;
            }
            else
            {
                while (stack.Count > 0)
                    num = stack.Pop() - num;
                return -num;
            }
        }

        public static List<int> ReadSequence(string line)
        {
            string pattern = @"(?: ?(-?\d+))+";
            Match match = Regex.Match(line, pattern);
            List<int> sequence = new List<int>();
            foreach (Capture c in match.Groups[1].Captures)
            {
                sequence.Add(int.Parse(c.Value));
            }
            return sequence;
        }

        public static Stack<int> GenerateStack(List<int> sequence, bool findingNumberOnEnd)
        {
            Stack<int> endNumbersStack = new Stack<int>();
            while (!AllZeroes(sequence))
            {
                List<int> differences = new List<int>();
                for (int i = 1; i < sequence.Count; i++)
                {
                    differences.Add(sequence[i] - sequence[i - 1]);
                }
                if (findingNumberOnEnd)
                    endNumbersStack.Push(differences[differences.Count - 1]);
                else
                    endNumbersStack.Push(differences[0]);
                sequence = differences;
            }
            return endNumbersStack;
        }
        public static int Extrapolate(string line, bool findingNumberOnEnd = true)
        {
            List<int> sequence = ReadSequence(line);

            int elementToExtrapolateFrom;
            if (findingNumberOnEnd)
                elementToExtrapolateFrom = sequence[sequence.Count - 1];
            else
                elementToExtrapolateFrom = sequence[0];

            Stack<int> endNumbersStack = GenerateStack(sequence, findingNumberOnEnd);

            elementToExtrapolateFrom += CalculateModifierFromStack(endNumbersStack, findingNumberOnEnd);
            return elementToExtrapolateFrom;
        }
        public static void Part1Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 1 %%%");
            int sumExtrapolated = 0;
            foreach (string line in instructions)
            {
                sumExtrapolated += Extrapolate(line);
            }
            Console.WriteLine(String.Format("The sum of all extrapolated numbers is {0}", sumExtrapolated));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");
            int sumExtrapolated = 0;
            foreach (string line in instructions)
            {
                sumExtrapolated += Extrapolate(line, false);
            }

            Console.WriteLine(String.Format("The sum of all extrapolated numbers is {0}", sumExtrapolated));
        }
        public static void Main(string[] args)
        {
            string path = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\";
            string day = "Day 9 - Oasis Report";

            string samplePath = path + day + @"\Sample.txt";
            string samplePath2 = path + day + @"\Sample2.txt";
            string fullPath = path + day + @"\Full.txt";
            string[] instructionsSample = System.IO.File.ReadAllLines(samplePath);
            //string[] instructionsSample2 = System.IO.File.ReadAllLines(samplePath);
            string[] instructionsFull = System.IO.File.ReadAllLines(fullPath);
            Part1Solution(instructionsFull);
            Part2Solution(instructionsFull);
        }
    }
}


