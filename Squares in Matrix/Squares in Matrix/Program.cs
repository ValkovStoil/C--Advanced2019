using System;
using System.Linq;

namespace Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var matrix = new string[dimensions[0], dimensions[1]];
            var squareMatrixNuber = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var chars = Console.ReadLine().Split();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = chars[j];
                }
            }


            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    var first = matrix[i, j];
                    var second = matrix[i, j + 1];
                    var third = matrix[i + 1, j];
                    var fourth = matrix[i + 1, j + 1];

                    if(first == second && second == third && third == fourth)
                    {
                        squareMatrixNuber++;
                    }
                }
            }

            Console.WriteLine(squareMatrixNuber);
        }
    }
}
