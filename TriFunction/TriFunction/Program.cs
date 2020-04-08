using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> equalOrLargerFunc = (word, number) => word.Sum(w => w) >= number;

            Func<List<string>, Func<string, int, bool>, int, string> myFunc = (word, compareFunc, number) =>
               word.FirstOrDefault(x => compareFunc(x, number));

            var number = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var outputName = myFunc(names, equalOrLargerFunc, number);

            Console.WriteLine(outputName);
        }
    }
}
