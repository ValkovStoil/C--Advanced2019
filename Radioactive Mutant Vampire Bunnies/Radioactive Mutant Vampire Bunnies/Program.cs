using System;
using System.Collections.Generic;
using System.Linq;

namespace Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        public static char[,] fieldMatrix;
        public static int startRow = 0;
        public static int startCol = 0;
        public static int playerLastRow = 0;
        public static int playerLastCol = 0;
        public static bool isDead;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Initialize(dimensions);

            var directions = Console.ReadLine()
                .ToLower()
                .ToCharArray();


            for (int moves = 0; moves < directions.Length; moves++)
            {
                var direction = directions[moves];

                //do the move and check if the player win
                switch (direction)
                {
                    case 'u':
                        Move(-1, 0);
                        break;
                    case 'd':
                        Move(1, 0);
                        break;
                    case 'l':
                        Move(0, -1);
                        break;
                    case 'r':
                        Move(0, 1);
                        break;
                }

                BunniSpred();

                if (isDead)
                {
                    PrintMatrix();
                    Console.WriteLine($"dead: {playerLastRow} {playerLastCol}");
                    Environment.Exit(0);
                }
            }

        }

        private static void Move(int row, int col)
        {
            if (!IsInside(startRow + row, startCol + col))
            {
                fieldMatrix[startRow, startCol] = '.';
                BunniSpred();
                PrintMatrix();
                Console.WriteLine($"won: {startRow} {startCol}");
                Environment.Exit(0);
            }

            if (fieldMatrix[startRow + row, startCol + col] == 'B')
            {
                BunniSpred();
                PrintMatrix();
                Console.WriteLine($"dead: {startRow + row} {startCol + col}");
                Environment.Exit(0);
            }

            fieldMatrix[startRow, startCol] = '.';

            startRow += row;
            startCol += col;

            fieldMatrix[startRow, startCol] = 'P';
        }

        private static void BunniSpred()
        {
            var bunniSpreadCoordinates = new Queue<Bunnies>();
            var bunniJumpTo = new Bunnies();

            //add the bunnie's to que
            for (int row = 0; row < fieldMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < fieldMatrix.GetLength(1); col++)
                {
                    if (fieldMatrix[row, col] == 'B')
                    {
                        if (IsInside(row - 1, col) && fieldMatrix[row - 1, col] != 'B')
                        {
                            bunniJumpTo = new Bunnies();
                            bunniJumpTo.row = row - 1;
                            bunniJumpTo.col = col;

                            bunniSpreadCoordinates.Enqueue(bunniJumpTo);
                        }

                        if (IsInside(row + 1, col) && fieldMatrix[row + 1, col] != 'B')
                        {
                            bunniJumpTo = new Bunnies();
                            bunniJumpTo.row = row + 1;
                            bunniJumpTo.col = col;

                            bunniSpreadCoordinates.Enqueue(bunniJumpTo);
                        }

                        if (IsInside(row, col - 1) && fieldMatrix[row, col - 1] != 'B')
                        {
                            bunniJumpTo = new Bunnies();
                            bunniJumpTo.row = row;
                            bunniJumpTo.col = col - 1;

                            bunniSpreadCoordinates.Enqueue(bunniJumpTo);
                        }

                        if (IsInside(row, col + 1) && fieldMatrix[row, col + 1] != 'B')
                        {
                            bunniJumpTo = new Bunnies();
                            bunniJumpTo.row = row;
                            bunniJumpTo.col = col + 1;

                            bunniSpreadCoordinates.Enqueue(bunniJumpTo);
                        }
                    }
                }
            }

            //spreed the bunnie's and chekc if they step on the player
            while (bunniSpreadCoordinates.Count != 0)
            {
                var bunni = bunniSpreadCoordinates.Dequeue();

                if(fieldMatrix[bunni.row,bunni.col] == 'P')
                {
                    isDead = true;
                    playerLastRow = bunni.row;
                    playerLastCol = bunni.col;
                }

                fieldMatrix[bunni.row, bunni.col] = 'B';
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < fieldMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < fieldMatrix.GetLength(1); col++)
                {
                    Console.Write(fieldMatrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < fieldMatrix.GetLength(0) &&
                col >= 0 && col < fieldMatrix.GetLength(1);
        }

        private static void Initialize(int[] dimensions)
        {
            fieldMatrix = new char[dimensions[0], dimensions[1]];
            for (int row = 0; row < fieldMatrix.GetLength(0); row++)
            {
                var input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < fieldMatrix.GetLength(1); col++)
                {
                    fieldMatrix[row, col] = input[col];

                    if(fieldMatrix[row,col] == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }
    }

    public class Bunnies
    {
        public int row { get; set; }
        public int col { get; set; }

        public Bunnies()
        {

        }
        public Bunnies(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
}
