using System;

namespace Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var board = new char[n, n];

            InitializeBoard(board);

            var knightMoves = new int[] { -2, 1, -2, -1, -1, 2, -1, -2, 1, 2, 1, -2, 2, 1, 2, -1 };
            var removeKnights = 0;
            var killerRow = 0;
            var killerCol = 0;

            while (true)
            {
                var maxAttacks = 0;

                for (int row = 0; row < board.GetLength(0); row++)
                {
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        int currentKnightsAttacks = 0;
                        var isKnight = IsKnight(board[row, col]);
                        if (isKnight)
                        {
                            for (int moves = 0; moves < knightMoves.Length; moves+=2)
                            {
                                var r = row + knightMoves[moves];
                                var c = col + knightMoves[moves + 1];
                                
                                if(IsKnightInside(board, r, c))
                                {
                                    currentKnightsAttacks++;
                                }

                            }
                        }

                        if (currentKnightsAttacks > maxAttacks)
                        {
                            maxAttacks = currentKnightsAttacks;
                            killerRow = row;
                            killerCol = col;
                        }
                    }
                }
                if (maxAttacks > 0)
                {
                    board[killerRow, killerCol] = 'D';
                    removeKnights++;
                }
                else
                {
                    Console.WriteLine(removeKnights);
                    break;
                }
            }
        }

        private static bool IsKnightInside(char[,] board, int row, int col)
        {
            return row >= 0 && row < board.GetLength(0) &&
                col >= 0 && col < board.GetLength(1) &&
                IsKnight(board[row, col]);
        }

        private static bool IsKnight(char k)
        {
            
            return k == 'K';
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
