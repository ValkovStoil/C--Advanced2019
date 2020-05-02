using System;

namespace ReVolt
{
    class Program
    {
        public class Player
        {
            public Player()
            {
                this.Sign = 'f';
            }

            public int Row { get; set; }

            public int Column { get; set; }

            public char Sign { get; set; }
        }

        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var countOfCommand = int.Parse(Console.ReadLine());

            var player = new Player();
            var field = new char[size, size];
            FillTheField(player, field);

            field[player.Row, player.Column] = '-';

            while (countOfCommand != 0)
            {
                var command = Console.ReadLine();

                PlayerMove(player, field, command);

                if(field[player.Row,player.Column] == 'B')
                {
                    PlayerMove(player, field, command);
                }
                else if(field[player.Row, player.Column] == 'T')
                {
                    StepOnTrap(player, command);
                }
                else if (field[player.Row,player.Column] == 'F')
                {
                    break;
                }

                countOfCommand--;
            }

            if(field[player.Row,player.Column] == 'F')
            {
                field[player.Row, player.Column] = player.Sign;
                Console.WriteLine($"Player won!");
            }
            else
            {
                field[player.Row, player.Column] = player.Sign;
                Console.WriteLine($"Player lost!");
            }

            PrintField(field);
        }

        private static void StepOnTrap(Player player, string command)
        {
            switch (command)
            {
                case "left":
                    player.Column++;
                    break;
                case "right":
                    player.Column--;
                    break;
                case "up":
                    player.Row++;
                    break;
                case "down":
                    player.Row--;
                    break;
            }
        }

        private static void PlayerMove(Player player, char[,] field, string command)
        {
            switch (command)
            {
                case "left":
                    if (player.Column - 1 < 0)
                    {
                        player.Column = field.GetLength(1) - 1;
                    }
                    else
                    {
                        player.Column--;
                    }
                    break;
                case "right":
                    if (player.Column + 1 == field.GetLength(1))
                    {
                        player.Column = 0;
                    }
                    else
                    {
                        player.Column++;
                    }
                    break;
                case "up":
                    if (player.Row - 1 < 0)
                    {
                        player.Row = field.GetLength(0) - 1;
                    }
                    else
                    {
                        player.Row--;
                    }
                    break;
                case "down":
                    if (player.Row + 1 == field.GetLength(0))
                    {
                        player.Row = 0;
                    }
                    else
                    {
                        player.Row++;
                    }
                    break;

            }
        }

        private static void PrintField(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void FillTheField(Player player, char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                var fieldSignInfo = Console.ReadLine();

                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (fieldSignInfo[col] == 'f')
                    {
                        player.Row = row;
                        player.Column = col;
                    }
                    field[row, col] = fieldSignInfo[col];
                }
            }
        }
    }
}
