using System;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            var prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x = (x + x * 0.2))
                .ToArray();


            foreach (var price in prices)
            {
                Console.WriteLine($"{price:F}");
            }

        }
    }
}
