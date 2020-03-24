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
        public static bool playerCollide = false;
        public static bool bunniColliade = false;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Initialize(dimensions);

            var directions = Console.ReadLine()
                .ToLower()
                .ToCharArray();

            //Find the start position
            StartingIndexes();

            var playerInsideField = false;

            for (int moves = 0; moves < directions.Length; moves++)
            {
                var direction = directions[moves];

                //do the move and check if the player win
                switch (direction)
                {
                    case 'u':
                        playerInsideField = IsInside(startRow - 1, startCol);
                        if (!playerInsideField)
                        {
                            playerLastRow = startRow;
                            playerLastCol = startCol;
                            break;
                        }
                        else
                        {
                            playerCollide = IsCollide(startRow - 1, startCol);
                        }
                        fieldMatrix[startRow, startCol] = '.';
                        startRow -= 1;

                        if (playerCollide)
                        {
                            break;
                        }
                        break;
                    case 'd':
                        playerInsideField = IsInside(startRow + 1, startCol);
                        if (!playerInsideField)
                        {
                            playerLastRow = startRow;
                            playerLastCol = startCol;
                            break;
                        }
                        else
                        {
                            playerCollide = IsCollide(startRow + 1, startCol);
                        }
                        fieldMatrix[startRow, startCol] = '.';
                        startRow += 1;

                        if (playerCollide)
                        {
                            break;
                        }
                        break;
                    case 'l':
                        playerInsideField = IsInside(startRow, startCol - 1);
                        if (!playerInsideField)
                        {
                            playerLastRow = startRow;
                            playerLastCol = startCol;
                            break;
                        }
                        else
                        {
                            playerCollide = IsCollide(startRow, startCol - 1);
                        }
                        fieldMatrix[startRow, startCol] = '.';
                        startCol -= 1;

                        if (playerCollide)
                        {
                            break;
                        }
                        break;
                    case 'r':
                        playerInsideField = IsInside(startRow, startCol + 1);
                        if (!playerInsideField)
                        {
                            playerLastRow = startRow;
                            playerLastCol = startCol;
                            break;
                        }
                        else
                        {
                            playerCollide = IsCollide(startRow, startCol + 1);
                        }
                        fieldMatrix[startRow, startCol] = '.';
                        startCol += 1;

                        if (playerCollide)
                        {
                            break;
                        }
                        break;
                }

                //player win the game
                if (!playerInsideField)
                {
                    BunnySpred();
                    PrintMatrix();
                    Console.WriteLine($"won: {startRow} {startCol}");
                    return;
                }

                if (playerCollide)
                {
                    BunnySpred();
                    PrintMatrix();
                    Console.WriteLine($"dead: {startRow} {startCol}");
                    return;
                }

                if(bunniColliade)
                {
                    BunnySpred();
                    PrintMatrix();
                    Console.WriteLine($"dead: {startRow} {startCol}");
                    return;
                }
                BunnySpred();

            }

        }

        private static bool IsCollide(int row, int col)
        {
            return fieldMatrix[row, col] == 'B';
        }

        private static void BunnySpred()
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
                bunniColliade = IsHitingPlayer(bunni.row, bunni.col);

                if (bunniColliade)
                {
                    startRow = bunni.row;
                    startCol = bunni.col;
                }
                fieldMatrix[bunni.row, bunni.col] = 'B';
            }
        }

        private static bool IsHitingPlayer(int row, int col)
        {
            return fieldMatrix[row, col] == 'P';
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

        private static void StartingIndexes()
        {
            for (int row = 0; row < fieldMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < fieldMatrix.GetLength(1); col++)
                {
                    if (fieldMatrix[row, col] == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
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
