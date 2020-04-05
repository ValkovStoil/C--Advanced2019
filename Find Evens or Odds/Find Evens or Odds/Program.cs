using System;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var startPoint = range[0];
            var endPoint = range[1];

            Predicate<int> oddPredicate = new Predicate<int>(Odd);
            Predicate<int> evenPredicate = new Predicate<int>(Even);

            var command = Console.ReadLine();

            for (int i = startPoint; i <= endPoint; i++)
            {
                if (command == "odd" && oddPredicate(i))
                {
                    Console.Write($"{i} ");
                }
                else if(command == "even" && evenPredicate(i))
                {
                    Console.Write($"{i} ");

                }
            }

        }

        private static bool Odd(int number)
        {
            return number % 2 != 0;
        }

        private static bool Even(int number)
        {
            return number % 2 == 0;
        }
    }
}
