using System;
using System.Linq;

namespace Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var columns = dimensions[1];
            var matrix = new string[rows, columns];

            FillMatrix(matrix);

            var commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var command = commands[0];


            while (command != "END")
            {
                if (commands.Count() == 5 && command == "swap")
                {
                    try
                    {
                        var rowOne = int.Parse(commands[1]);
                        var columnOne = int.Parse(commands[2]);
                        var rowTwo = int.Parse(commands[3]);
                        var columnTwo = int.Parse(commands[4]);

                        var temp = matrix[rowOne, columnOne];
                        matrix[rowOne, columnOne] = matrix[rowTwo, columnTwo];
                        matrix[rowTwo, columnTwo] = temp;

                        PrintMatrix(matrix);

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                command = commands[0];
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static void FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
        }
    }
}
