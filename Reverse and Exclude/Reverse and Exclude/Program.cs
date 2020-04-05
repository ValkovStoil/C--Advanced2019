using System;
using System.Linq;

namespace Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse();

            var n = int.Parse(Console.ReadLine());

            var divisble = new Func<int, int, bool>(Dibisible);

            var output = numbers.Where(x => !divisble(x, n));

            Console.WriteLine(string.Join(" ", output));
        }

        private static bool Dibisible(int num1, int num2)
        {
            return num1 % num2 == 0;
        }
    }
}
