using System;
using System.Linq;
using System.Collections.Generic;

namespace Bombs
{
    class Program
    {
        public static List<int> bombsPossition = new List<int>();
        public static List<int> damageSpread = new List<int>() { -1, -1, -1, 0, -1, 1, 0, -1, 0, 1, 1, -1, 1, 0, 1, 1 };
        public static int[,] bombsMatrix;
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());

            bombsMatrix = new int[size, size];

            Initialaize(bombsMatrix);

            bombsPossition = Console.ReadLine()
                .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            for (int explode = 0; explode < bombsPossition.Count(); explode += 2)
            {
                var bombRow = bombsPossition[explode];
                var bombCol = bombsPossition[explode + 1];

                if (bombsMatrix[bombRow, bombCol] > 0)
                {
                    DamageDone(bombRow, bombCol);
                    bombsMatrix[bombRow, bombCol] = 0;
                }

            }

            long sum = 0;
            var cellCount = 0;
            for (int row = 0; row < bombsMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < bombsMatrix.GetLength(1); col++)
                {
                    if (bombsMatrix[row, col] > 0)
                    {
                        sum += bombsMatrix[row, col];
                        cellCount++;
                    }
                }
            }
            Console.WriteLine($"Alive cells: {cellCount}");
            Console.WriteLine($"Sum: {sum}");
            PrintMatrix();

        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < bombsMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < bombsMatrix.GetLength(1); col++)
                {
                    Console.Write(bombsMatrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void DamageDone(int bombRow, int bombCol)
        {
            for (int dmg = 0; dmg < damageSpread.Count() - 1; dmg += 2)
            {
                var row = bombRow + damageSpread[dmg];
                var col = bombCol + damageSpread[dmg + 1];

                if (IsInsideNotA(bombsMatrix, row, col) && bombsMatrix[row, col] > 0)
                {
                    bombsMatrix[row, col] -= bombsMatrix[bombRow, bombCol];
                }
                ;
            }
        }

        private static bool IsInsideNotA(int[,] bombsMatrix, int row, int col)
        {
            return row >= 0 && row < bombsMatrix.GetLength(0) &&
                col >= 0 && col < bombsMatrix.GetLength(1);
        }

        private static void Initialaize(int[,] bombsMatrix)
        {
            for (int row = 0; row < bombsMatrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < bombsMatrix.GetLength(1); col++)
                {
                    bombsMatrix[row, col] = input[col];
                }
            }
        }
    }
}
