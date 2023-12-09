using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class LCMHelper
    {
        public static long CalculateLCMFromListsOfFactors(List<List<int>> factorsForEachPath)
        {
            Dictionary<int, int> uniqueFactorsAndHighestPower = new Dictionary<int, int>();

            // Examine each path's factors
            foreach (List<int> factors in factorsForEachPath)
            {
                Dictionary<int, int> factorsAndFrequency = new Dictionary<int, int>();
                // Examine each factor to find factors and frequencies
                foreach (int factor in factors)
                {
                    // Factor already included
                    if (factorsAndFrequency.ContainsKey(factor))
                        factorsAndFrequency[factor]++;
                    else
                        factorsAndFrequency.Add(factor, 1);
                }

                // Update overall unique factors and highest powers
                foreach (KeyValuePair<int, int> factorFreq in factorsAndFrequency)
                {
                    // Not unique
                    if (uniqueFactorsAndHighestPower.ContainsKey(factorFreq.Key))
                    {
                        // Check if power can be raised
                        if (factorFreq.Value > uniqueFactorsAndHighestPower[factorFreq.Key])
                        {
                            uniqueFactorsAndHighestPower[factorFreq.Key] = factorFreq.Value;
                        }
                    }
                    // Unique
                    else
                    {
                        uniqueFactorsAndHighestPower[factorFreq.Key] = factorFreq.Value;
                    }
                }
            }

            // construct LCM
            long lcm = 1;
            foreach (KeyValuePair<int, int> pair in uniqueFactorsAndHighestPower)
            {
                lcm *= Convert.ToInt32(Math.Pow(pair.Key, pair.Value));
            }



            return lcm;



        }
    }
}
