using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n, n];
            var diagonalOne = 0;
            var diagonalTwo = 0;

            for (int i = 0; i < n; i++)
            {
                var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                diagonalOne += matrix[i, i];
                diagonalTwo += matrix[n - 1 - i, i];
            }

            Console.WriteLine(Math.Abs(diagonalOne - diagonalTwo));
        }
    }
}
