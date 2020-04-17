using System;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var inputData = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                var inputString = int.Parse(Console.ReadLine());
                inputData.Text.Add(inputString);
            }

            var indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var firstIndex = indexes[0];
            var secondIndex = indexes[1];

            inputData.SwapElements(firstIndex, secondIndex);

            Console.WriteLine(inputData.ToString());
        }
    }
}
