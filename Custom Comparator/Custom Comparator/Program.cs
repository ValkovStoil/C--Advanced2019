using System;
using System.Linq;

namespace Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToArray();


            Array.Sort(numbers,
                (x, y) =>
                {
                    int compX = Math.Abs(x % 2);
                    int compY = Math.Abs(y % 2);
                    return compX.CompareTo(compY);
                });

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
