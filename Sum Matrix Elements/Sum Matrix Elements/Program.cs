using System;
using System.Linq;

namespace Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new string[] { ", " },
                StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[input[0], input[1]];

            var row = matrix.GetLength(0);
            var colm = matrix.GetLength(1);
            var sumOfAllElements = 0;

            for (int i = 0; i < row; i++)
            {
                var digits = Console.ReadLine().Split(new string[] { ", " },
                    StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < colm; j++)
                {
                    matrix[i, j] = digits[j];
                    sumOfAllElements += matrix[i, j];
                }
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sumOfAllElements);
        }
    }
}
