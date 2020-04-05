using System;
using System.Collections.Generic;
using System.Linq;

namespace List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            var predicate = new Func<int,int[], bool>(FindDivisableNumbers);

            var output = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                if (predicate(i, numbers))
                {
                    output.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ",output));
        }

        private static bool FindDivisableNumbers(int num, int[] numbers)
        {
            foreach (var number in numbers)
            {
                if(num % number != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
