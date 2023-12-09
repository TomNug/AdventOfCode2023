using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class PrimeHelper
    {
        public static List<int> primes = new List<int>();
        public static List<int> GeneratePrimes(int n)
        {
            primes = new List<int>();

            bool[] isPrime = new bool[n + 1];

            // Initialize the array
            for (int i = 2; i <= n; i++)
            {
                isPrime[i] = true;
            }

            // Apply the Sieve of Eratosthenes algorithm
            for (int p = 2; p * p <= n; p++)
            {
                if (isPrime[p])
                {
                    for (int i = p * p; i <= n; i += p)
                    {
                        isPrime[i] = false;
                    }
                }
            }

            // Collect the prime numbers
            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }
            primes.Reverse();
            return primes;
        }

        // Finds the highest prime factor of a number
        public static int PrimeFactor(int num)
        {
            foreach (int prime in primes)
            {
                double result = (double)num / prime;
                if (result % 1 == 0)
                {
                    return prime;
                }
            }
            return -1;
        }
        // Calculates the prime factors of a number
        public static List<int> PrimeFactors(int num)
        {
            // List of factors
            List<int> factors = new List<int>();

            // Until found all factors
            while (num > 1)
            {
                // Find highest factor
                int factor = PrimeFactor(num);
                // Add to list
                factors.Add(factor);
                // Divide number by factor
                num /= factor;
            }
            return factors;
        }



    }
}
