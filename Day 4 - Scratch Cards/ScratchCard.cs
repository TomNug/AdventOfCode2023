using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_4___Scratch_Cards
{
    public class ScratchCard
    {
        public int Number { get; set; }
        public HashSet<int> WinningNumbers { get; set; }
        public HashSet<int> Numbers { get; set; }
        public ScratchCard(int number, List<int> winningNumbers, List<int> numbers)
        {
            Number = number;
            foreach (int num in winningNumbers)
                WinningNumbers.Add(num);
            foreach (int num in numbers)
                Numbers.Add(num);
        }
    }
}
