using System;
using System.Linq;

namespace Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            numbers = numbers.Where(x => x % 2 == 0)
                .ToList();

            numbers.Sort();

            Console.WriteLine(string.Join(", ",numbers));
        }
    }
}
