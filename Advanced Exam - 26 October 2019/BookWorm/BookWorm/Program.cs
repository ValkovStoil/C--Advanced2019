using System;
using System.Linq;
using System.Text;

namespace BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialString = Console.ReadLine();
            var size = int.Parse(Console.ReadLine());

            var fieldMatrix = new char[size, size];
            var player = new Player();
            var currentString = new StringBuilder(initialString);

            FillTheField(fieldMatrix, player);

            var command = Console.ReadLine();

            while (command != "end")
            {
                Move(fieldMatrix, player, currentString, command);

                command = Console.ReadLine();
            }

            Console.WriteLine(currentString.ToString());
            PrintField(fieldMatrix);
        }

        private static void PrintField(char[,] fieldMatrix)
        {
            for (int row = 0; row < fieldMatrix.GetLength(0); row++)
            {

                for (int col = 0; col < fieldMatrix.GetLength(1); col++)
                {
                    Console.Write(fieldMatrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static void Move(char[,] fieldMatrix, Player player, StringBuilder currentString, string command)
        {

            switch (command)
            {
                case "left":
                    if (player.Column == 0)
                    {
                        currentString.Length--;
                    }
                    else
                    {
                        fieldMatrix[player.Row, player.Column] = '-';
                        player.Column--;
                        if (fieldMatrix[player.Row, player.Column] != '-')
                        {
                            currentString.Append(fieldMatrix[player.Row, player.Column]);
                        }
                        fieldMatrix[player.Row, player.Column] = player.Sign;
                    }
                    break;
                case "right":
                    if (player.Column == fieldMatrix.GetLength(1) - 1)
                    {
                        currentString.Length--;
                    }
                    else
                    {
                        fieldMatrix[player.Row, player.Column] = '-';
                        player.Column++;
                        if (fieldMatrix[player.Row, player.Column] != '-')
                        {
                            currentString.Append(fieldMatrix[player.Row, player.Column]);
                        }
                        fieldMatrix[player.Row, player.Column] = player.Sign;
                    }
                    break;
                case "up":
                    if (player.Row == 0)
                    {
                        currentString.Length--;
                    }
                    else
                    {
                        fieldMatrix[player.Row, player.Column] = '-';
                        player.Row--;
                        if (fieldMatrix[player.Row, player.Column] != '-')
                        {
                            currentString.Append(fieldMatrix[player.Row, player.Column]);
                        }
                        fieldMatrix[player.Row, player.Column] = player.Sign;
                    }
                    break;
                case "down":
                    if (player.Row == fieldMatrix.GetLength(0) - 1)
                    {
                        currentString.Length--;
                    }
                    else
                    {
                        fieldMatrix[player.Row, player.Column] = '-';   
                        player.Row++;
                        if (fieldMatrix[player.Row, player.Column] != '-')
                        {
                            currentString.Append(fieldMatrix[player.Row, player.Column]);
                        }
                        fieldMatrix[player.Row, player.Column] = player.Sign;
                    }
                    break;
            }
        }

        public class Player
        {
            public Player()
            {
                this.Sign = 'P';
            }

            public int Row { get; set; }

            public int Column { get; set; }

            public char Sign { get; set; }
        }

        private static void FillTheField(char[,] fieldMatrix, Player player)
        {
            for (int row = 0; row < fieldMatrix.GetLength(0); row++)
            {

                var inputLine = Console.ReadLine();

                for (int col = 0; col < fieldMatrix.GetLength(1); col++)
                {
                    fieldMatrix[row, col] = inputLine[col];

                    if (inputLine[col] == 'P')
                    {
                        player.Row = row;
                        player.Column = col;
                    }
                }
            }
        }
    }
}
