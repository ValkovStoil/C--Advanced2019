using System;
using System.Linq;

namespace Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rows = input[0];
            var columns = input[1];
            var matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {

                var numInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = numInput[col];
                }
            }

            for (int col = 0; col < columns; col++)
            {
                var sumOfColumns = 0;
                for (int row = 0; row < rows; row++)
                {
                    sumOfColumns += matrix[row, col];
                }
                Console.WriteLine(sumOfColumns);
            }
        }
    }
}
