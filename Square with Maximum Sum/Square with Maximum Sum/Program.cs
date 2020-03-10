using System;
using System.Linq;

namespace Square_with_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = Console.ReadLine().Split(", ")
                .Select(int.Parse)
                .ToArray();
            var rows = dimentions[0];
            var columns= dimentions[1];

            var matrix = new int[rows, columns];

            var biggestSubmatrix = new int[2, 2];
            var sum = 0;

            for (int row = 0; row < rows; row++)
            {
                var inputNumbers = Console.ReadLine().Split(", ")
                    .Select(int.Parse)
                    .ToArray();


                for (int col = 0; col < columns; col++)
                {
                    matrix[row,col] = inputNumbers[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < columns - 1; col++)
                {
                    var tempSym = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if(tempSym > sum)
                    {
                        sum = tempSym;
                        biggestSubmatrix[0, 0] = matrix[row, col];
                        biggestSubmatrix[0, 1] = matrix[row, col + 1];
                        biggestSubmatrix[1, 0] = matrix[row + 1, col];
                        biggestSubmatrix[1, 1] = matrix[row + 1, col + 1];
                    }
                }
            }

            for (int row = 0; row < biggestSubmatrix.GetLength(0); row++)
            {
                for (int col = 0; col < biggestSubmatrix.GetLength(1); col++)
                {
                    Console.Write($"{biggestSubmatrix[row, col]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(sum);
        }
    }
}
