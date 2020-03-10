using System;
using System.Linq;

namespace Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = int.Parse(Console.ReadLine());

            var matrix = new char[dimentions, dimentions];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            var symbolToFind = char.Parse(Console.ReadLine());

            var findSymbol = FindSymbol(symbolToFind, matrix);

            if (findSymbol)
            {
                var possition = FindPossition(symbolToFind, matrix);

                Console.WriteLine(possition);
            }
            else
            {
                Console.WriteLine($"{symbolToFind} does not occur in the matrix");
            }
        }

        private static string FindPossition(char symbolToFind, char[,] matrix)
        {
            var result = "";

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row,col] == symbolToFind)
                    {
                        return result = $"({row}, {col})";
                    }
                } 
            }

            return result;
        }

        private static bool FindSymbol(char symbolToFind,char[,] matrix)
        {
            return matrix.Cast<char>().Contains(symbolToFind);
        }
    }
}
