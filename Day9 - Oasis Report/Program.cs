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

        public static int CalculateModifierFromStack(Stack<int> stack)
        {
            int num = stack.Pop();

            while(stack.Count > 0)
                num += stack.Pop();

            return num;
        }
        public static int Extrapolate(string line)
        {
            string pattern = @"(?: ?(-?\d+))+";
            Match match = Regex.Match(line, pattern);
            List<int> sequence = new List<int>();
            foreach (Capture c in match.Groups[1].Captures)
            {
                sequence.Add(int.Parse(c.Value));
            }

            int lastElementInSequence = sequence[sequence.Count - 1];

            Stack<int> endNumbersStack = new Stack<int>();

            while (!AllZeroes(sequence))
            {
                List<int> differences = new List<int>();
                for(int i = 1; i < sequence.Count; i++)
                {
                    differences.Add(sequence[i] - sequence[i - 1]);
                }
                endNumbersStack.Push(differences[differences.Count - 1]);
                sequence = differences;
            }

            lastElementInSequence += CalculateModifierFromStack(endNumbersStack);
            return lastElementInSequence;
        }
        public static void Part1Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 1 %%%");
            int sumExtrapolated = 0;
            foreach(string line in instructions)
            {
                sumExtrapolated += Extrapolate(line);
            }
            Console.WriteLine(String.Format("The sum of all extrapolated numbers is {0}", sumExtrapolated));
        }

        public static void Part2Solution(string[] instructions)
        {
            Console.WriteLine("\n%%% Part 2 %%%");


            Console.WriteLine(String.Format("You get to ZZZ in {0} steps", 5));
        }
        public static void Main(string[] args)
        {
            string path = @"C:\Users\Tom\Documents\Projects\Advent\2023\AdventOfCode2023\";
            string day = "Day9 - Oasis Report";

            string samplePath = path + day + @"\Sample.txt";
            string samplePath2 = path + day + @"\Sample2.txt";
            string fullPath = path + day + @"\Full.txt";
            string[] instructionsSample = System.IO.File.ReadAllLines(samplePath);
            //string[] instructionsSample2 = System.IO.File.ReadAllLines(samplePath);
             string[] instructionsFull = System.IO.File.ReadAllLines(fullPath);
            Part1Solution(instructionsFull);
            Part2Solution(instructionsSample);
        }
    }
}


