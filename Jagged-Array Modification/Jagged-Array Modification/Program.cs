using System;
using System.Linq;

namespace Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimentions = int.Parse(Console.ReadLine());

            var matrix = new int[dimentions, dimentions];
            var rows = matrix.GetLength(0);
            var colums = matrix.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                var numbers = Console.ReadLine().Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < colums; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            var commands = Console.ReadLine().Split(' ').ToArray();

            while (commands[0] != "END")
            {
                var command = commands[0];
                var row = int.Parse(commands[1]);
                var col = int.Parse(commands[2]);
                var param = int.Parse(commands[3]);


                var inBound = InBound(matrix, row, col);

                if (inBound)
                {
                    switch (command)
                    {
                        case "Add":
                            matrix[row, col] += param;
                            break;
                        case "Subtract":
                            matrix[row, col] -= param;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }


                commands = Console.ReadLine().Split(' ').ToArray();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < colums; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }



        private static bool InBound(int[,] matrix, int row, int col)
        {
            if (row < 0 || col < 0) return false;

            if (matrix.GetLength(0) > row && matrix.GetLength(1) > col) return true;

            return false;
        }
    }
}
