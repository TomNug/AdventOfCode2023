using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day8
{
    public class ParserHelper
    {
        public static Dictionary<string, Node> ParseInstructions(string[] instructions)
        {
            Dictionary<string, Node> result = new Dictionary<string, Node>();

            for (int line = 2; line < instructions.Length; line++)
            {
                string pattern = @"([A-Z]{3}) = \(([A-Z]{3}), ([A-Z]{3})\)";
                Match match = Regex.Match(instructions[line], pattern);
                string name = match.Groups[1].Value;
                string left = match.Groups[2].Value;
                string right = match.Groups[3].Value;

                Node newNode = new Node(left, right);
                result.Add(name, newNode);
            }
            return result;
        }

        public static (Dictionary<string, Node>, List<string>) ParseInstructionsPart2(string[] instructions)
        {
            Dictionary<string, Node> nodes = new Dictionary<string, Node>();
            List<string> starts = new List<string>();
            for (int line = 2; line < instructions.Length; line++)
            {
                string pattern = @"([A-Z,0-9]{3}) = \(([A-Z,0-9]{3}), ([A-Z,0-9]{3})\)";
                Match match = Regex.Match(instructions[line], pattern);
                string name = match.Groups[1].Value;
                string left = match.Groups[2].Value;
                string right = match.Groups[3].Value;

                // Keep track of all nodes which end in A
                if (name[2] == 'A')
                    starts.Add(name);

                Node newNode = new Node(left, right);
                nodes.Add(name, newNode);
            }
            return (nodes, starts);
        }
    }
}
