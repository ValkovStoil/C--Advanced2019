using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var symbols = new SortedDictionary<char, int>();

            var stringInput = Console.ReadLine();

            foreach (var @char in stringInput)
            {
                if (!symbols.ContainsKey(@char))
                {
                    symbols[@char] = 0;
                }
                symbols[@char]++;
            }

            foreach (var kvp in symbols)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
