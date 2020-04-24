using System;

namespace TronRacers
{
    class Program
    {
        public static PlayerCordinates firstPlayer = new PlayerCordinates('f');
        public static PlayerCordinates secondPlayer = new PlayerCordinates('s');

        static void Main(string[] args)
        {
            var matrixRowsAndCols = int.Parse(Console.ReadLine());

            var gameField = new char[matrixRowsAndCols, matrixRowsAndCols];


            FillUpTheMatrix(matrixRowsAndCols, gameField, firstPlayer, secondPlayer);

            while (true)
            {
                var commnads = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var firstPlayerMove = commnads[0];
                var secondPlayerMove = commnads[1];
                
                Move(gameField, firstPlayer, firstPlayerMove);
                Move(gameField, secondPlayer, secondPlayerMove);

                var checkFirstPlayer = CheckForDeadPlayers(gameField, firstPlayer);
                if (!checkFirstPlayer )
                {
                    PrintMatrix(gameField);
                    return;
                }

                var checkSecondPlayer = CheckForDeadPlayers(gameField, secondPlayer);
                if (!checkSecondPlayer)
                {
                    PrintMatrix(gameField);
                    return;
                }
            }

        }

        private static bool CheckForDeadPlayers(char[,] gameField, PlayerCordinates player)
        {
            if (gameField[player.Row, player.Col] == '*')
            {
                gameField[player.Row, player.Col] = player.Sign;
                return true;
            }
            else
            {
                gameField[player.Row, player.Col] = 'x';
                return false;
            }
        }

        private static void PrintMatrix(char[,] gameField)
        {
            for (int rows = 0; rows < gameField.GetLength(0); rows++)
            {
                for (int columns = 0; columns < gameField.GetLength(1); columns++)
                {
                    Console.Write(gameField[rows, columns]);
                }
                Console.WriteLine();
            }
        }

        private static void Move(char[,] gameField, PlayerCordinates player, string playerMove)
        {
            switch (playerMove)
            {
                case "up":
                    if (player.Row == 0)
                    {
                        player.Row = gameField.GetLength(1) - 1;
                    }
                    else
                    {
                        player.Row--;
                    }
                    break;
                case "down":
                    if (player.Row == gameField.GetLength(1) - 1)
                    {
                        player.Row = 0;
                    }
                    else
                    {
                        player.Row++;
                    }
                    break;
                case "left":
                    if (player.Col == 0)
                    {
                        player.Col = gameField.GetLength(0) - 1;
                    }
                    else
                    {
                        player.Col--;
                    }
                    break;
                case "right":
                    if (player.Col == gameField.GetLength(0) - 1)
                    {
                        player.Col = 0;
                    }
                    else
                    {
                        player.Col++;
                    }
                    break;
            }
        }

        private static void FillUpTheMatrix(int matrixRowsAndCols, char[,] gameField, PlayerCordinates firstPlayer, PlayerCordinates secondPlayer)
        {
            for (int rows = 0; rows < matrixRowsAndCols; rows++)
            {
                var field = Console.ReadLine();

                for (int columns = 0; columns < matrixRowsAndCols; columns++)
                {
                    gameField[rows, columns] = field[columns];

                    if (field[columns] == firstPlayer.Sign)
                    {
                        firstPlayer.Row = rows;
                        firstPlayer.Col = columns;
                    }

                    if (field[columns] == secondPlayer.Sign)
                    {
                        secondPlayer.Row = rows;
                        secondPlayer.Col = columns;
                    }
                }
            }
        }
    }
    public class PlayerCordinates
    {

        public PlayerCordinates(char sign)
        {
            this.Sign = sign;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public char Sign { get; set; }
    }
}
