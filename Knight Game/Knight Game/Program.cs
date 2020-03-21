using System;

namespace Knight_Game
{
    class Program
    {
        public static int removeKnight = 0;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var board = new char[n, n];

            InitializeBoard(board);
            //TODO

            for (int row = 0; row < board.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    var isKnight = IsKnight(board[row, col]);

                    //Horizontal check
                    if (isKnight)
                    {
                        CheckHorizontal(row, col, board);
                    }

                    //Vertical check
                    if (row < board.GetLength(0) - 1 && isKnight)
                    {
                        CheckVertical(row, col, board);
                    }
                }
            }

            Console.WriteLine(removeKnight);
        }

        private static void CheckHorizontal(int row, int col, char[,] board)
        {
            var isKnight = false;
            if (row < board.GetLength(0) - 1)
            {
                if (col < board.GetLength(1) - 2)
                {
                    isKnight = IsKnight(board[row + 1, col + 2]);
                    if (isKnight)
                    {
                        board[row + 1, col + 2] = '0';
                        removeKnight++;
                    }
                }
                if (col > 1)
                {
                    isKnight = IsKnight(board[row + 1, col - 2]);
                    if (isKnight)
                    {
                        board[row + 1, col - 2] = '0';
                        removeKnight++;
                    }
                }
            }
        }

        private static void CheckVertical(int row, int col, char[,] board)
        {
            var isKnight = false;
            var lenght = 2;
            if(board.GetLength(1) % 2 == 0)
            {
                lenght = 3;
            }

            if (col < board.GetLength(1) - 1 && col > 0 && row < board.GetLength(0) - lenght)
            {
                isKnight = IsKnight(board[row + 2, col + 1]);
                if (isKnight)
                {
                    board[row + 2, col + 1] = '0';
                    removeKnight++;
                }

                isKnight = IsKnight(board[row + 2, col - 1]);
                if (isKnight)
                {
                    board[row + 2, col - 1] = '0';
                    removeKnight++;
                }

            }
            if (col == 0 && row < board.GetLength(0) - 2)
            {
                isKnight = IsKnight(board[row + 2, col + 1]);
                if (isKnight)
                {
                    board[row + 2, col + 1] = '0';
                    removeKnight++;
                }
            }
            if (col == board.GetLength(1) - 1 && row < board.GetLength(0) - 2)
            {
                isKnight = IsKnight(board[row + 2, col - 1]);
                if (isKnight)
                {
                    board[row + 2, col - 1] = '0';
                    removeKnight++;
                }
            }
        }

        private static bool IsKnight(char v)
        {
            var k = 'K';
            return k == v;
        }

        private static void InitializeBoard(char[,] board)
        {

            for (int row = 0; row < board.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Trim().ToCharArray();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = input[col];
                }
            }
        }
    }
}
