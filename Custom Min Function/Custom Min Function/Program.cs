using System;
using System.Linq;

namespace Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> smallest = new Func<int[], int>(SmallestNumber);

            Console.WriteLine(smallest(numbers));
        }

        public static int SmallestNumber(int[] numbers)
        {
            var smallest = int.MaxValue;

            foreach (var number in numbers)
            {
                if(number < smallest)
                {
                    smallest = number;
                }
            }

            return smallest;
        }
    }
}
