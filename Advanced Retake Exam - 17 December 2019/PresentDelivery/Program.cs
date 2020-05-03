using System;
using System.Linq;

namespace PresentDelivery
{
    public class program
    {
        private static char[][] neighbourhood;
        private static int santaRow;
        private static int santaCol;
        private static int happyKids;

        static void Main()
        {
            int presentsCount = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            FillMatrix(n);

            string direction;
            while ((direction = Console.ReadLine()) != "Christmas morning" && presentsCount > 0)
            {
                int nextRow = santaRow;
                int nextCol = santaCol;
                CalculateNextCoordinates(direction, ref nextRow, ref nextCol);
                char nextSymbol = neighbourhood[nextRow][nextCol];

                if (nextSymbol == 'V')
                {
                    presentsCount--;
                    happyKids++;
                }
                else if (nextSymbol == 'C')
                {
                    GiveGiftsToAllAround(ref presentsCount, nextRow, nextCol);
                }

                neighbourhood[santaRow][santaCol] = '-';
                neighbourhood[nextRow][nextCol] = 'S';

                santaRow = nextRow;
                santaCol = nextCol;
            }

            if (direction != "Christmas morning" && presentsCount == 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            PrintMatrix(n);

            int niceKidsLeftCount = CountOfNiceKidsLeft(n);

            if (niceKidsLeftCount == 0)
            {
                Console.WriteLine($"Good job, Santa! {happyKids} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {niceKidsLeftCount} nice kid/s.");
            }
        }

        private static int CountOfNiceKidsLeft(int n)
        {
            int niceKidsLeftCount = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (neighbourhood[row][col] == 'V')
                    {
                        niceKidsLeftCount++;
                    }
                }
            }

            return niceKidsLeftCount;
        }

        private static void PrintMatrix(int n)
        {
            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(String.Join(" ", neighbourhood[row]));
            }
        }

        private static void GiveGiftsToAllAround(ref int presentsCount, int nextRow, int nextCol)
        {
            int countOfGiftsGiven = 0;

            if (IsKidOnCoordinates(nextRow, nextCol - 1))
            {
                ProceedCookie(nextRow, nextCol - 1, ref countOfGiftsGiven);
            }

            if (IsKidOnCoordinates(nextRow, nextCol + 1))
            {
                ProceedCookie(nextRow, nextCol + 1, ref countOfGiftsGiven);
            }

            if (IsKidOnCoordinates(nextRow - 1, nextCol))
            {
                ProceedCookie(nextRow - 1, nextCol, ref countOfGiftsGiven);
            }

            if (IsKidOnCoordinates(nextRow + 1, nextCol))
            {
                ProceedCookie(nextRow + 1, nextCol, ref countOfGiftsGiven);
            }

            presentsCount -= countOfGiftsGiven;
        }
        private static void ProceedCookie(int nextRow, int nextCol, ref int countOfGiftsGiven)
        {
            if (neighbourhood[nextRow][nextCol] == 'V')
            {
                happyKids++;
            }

            neighbourhood[nextRow][nextCol] = '-';

            countOfGiftsGiven++;
        }

        private static bool IsKidOnCoordinates(int row, int col)
        {
            return neighbourhood[row][col] == 'X' ||
                neighbourhood[row][col] == 'V';
        }

        private static void CalculateNextCoordinates(string direction, ref int nextRow, ref int nextCol)
        {
            if (direction == "up")
            {
                nextRow--;
            }
            else if (direction == "down")
            {
                nextRow++;
            }
            else if (direction == "left")
            {
                nextCol--;
            }
            else if (direction == "right")
            {
                nextCol++;
            }
        }

        private static void FillMatrix(int n)
        {
            neighbourhood = new char[n][];
            bool santaFound = false;
            for (int row = 0; row < n; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ')
                    .Select(char.Parse)
                    .ToArray();

                if (!santaFound)
                {
                    for (int col = 0; col < currentRow.Length; col++)
                    {
                        if (currentRow[col] == 'S')
                        {
                            santaRow = row;
                            santaCol = col;
                            santaFound = true;

                            break;
                        }
                    }
                }

                neighbourhood[row] = currentRow;
            }
        }
    }
}