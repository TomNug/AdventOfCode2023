using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class Node
    {
        public string left { get; set; }
        public string right { get; set; }
        public Node(string left, string right)
        {
            this.left = left;
            this.right = right;
        }
        public string Navigate(char direction)
        {
            if (direction == 'L')
                return left;
            else
                return right;
        }
    }
}
