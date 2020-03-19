using System;
using System.Linq;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[dimensions[0], dimensions[1]];
            var sum = 0;
            var startIndexRow = 0;
            var startIndexCol = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }


            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    var rowOne = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2];
                    var rowTwo = matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2];
                    var rowThre = matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    var currentSum = rowOne + rowTwo + rowThre;

                    if(sum < currentSum)
                    {
                        sum = currentSum;
                        startIndexRow = i;
                        startIndexCol = j;
                    }

                }
            }

            Console.WriteLine($"Sum = {sum}");

            var outputMatrix = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    outputMatrix[i, j] = matrix[startIndexRow + i, startIndexCol + j];
                }
            }

            for (int i = 0; i < outputMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < outputMatrix.GetLength(1); j++)
                {
                    Console.Write($"{outputMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
