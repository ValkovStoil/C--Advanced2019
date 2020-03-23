using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        public static char[,] matrixField;
        static void Main(string[] args)
        {
            //get input from the console 
            var size = int.Parse(Console.ReadLine());
            var commands = Console.ReadLine()
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            //initialize the matrix
            matrixField = new char[size, size];
            Initialize();

            //find the starting coordinates
            var start = StartCoordinats().Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var startRow = start[0];
            var startCol = start[1];

            //find amount of coal's in the field
            var coal = 'c';
            var coalCount = AmountOfCoal(coal);

            for (int com = 0; com < commands.Length; com++)
            {
                var command = commands[com];
                char symbol = matrixField[startRow, startCol];

                switch (command)
                {
                    //check if the command can be done and the symbol on that coordinates
                    case "up":
                        if (IsInside(startRow - 1, startCol))
                        {
                            startRow -= 1;
                            symbol = matrixField[startRow, startCol];
                        }
                        break;
                    case "down":
                        if (IsInside(startRow + 1, startCol))
                        {
                            startRow += 1;
                            symbol = matrixField[startRow, startCol];
                        }
                        break;
                    case "right":
                        if (IsInside(startRow, startCol + 1))
                        {
                            startCol += 1;
                            symbol = matrixField[startRow, startCol];
                        }
                        break;
                    case "left":
                        if (IsInside(startRow, startCol - 1))
                        {
                            startCol -= 1;
                            symbol = matrixField[startRow, startCol];
                        }
                        break;
                }

                if (symbol == 'e')
                {
                    Console.WriteLine($"Game over! ({startRow}, {startCol})");
                    return;
                }
                if(symbol == coal)
                {
                    coalCount--;
                    matrixField[startRow, startCol] = '*';
                }

                if(coalCount == 0)
                {
                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                    return;
                }
            }

            Console.WriteLine($"{coalCount} coals left. ({startRow}, {startCol})");
        }

        private static int AmountOfCoal(char coal)
        {
            var count = 0;

            for (int row = 0; row < matrixField.GetLength(0); row++)
            {
                for (int col = 0; col < matrixField.GetLength(1); col++)
                {
                    if (matrixField[row, col] == coal)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        //check if the coordinates are in the matrix
        private static bool IsInside(int startRow, int startCol)
        {
            return startRow >= 0 && startRow < matrixField.GetLength(0) &&
                startCol >= 0 && startCol < matrixField.GetLength(1);
        }

        private static string StartCoordinats()
        {
            var rowCoord = 0;
            var columngCord = 0;
            for (int row = 0; row < matrixField.GetLength(0); row++)
            {
                for (int col = 0; col < matrixField.GetLength(1); col++)
                {
                    if (matrixField[row, col] == 's')
                    {
                        rowCoord = row;
                        columngCord = col;
                    }
                }
            }
            return rowCoord + "," + columngCord;
        }

        private static void Initialize()
        {
            for (int row = 0; row < matrixField.GetLength(0); row++)
            {
                var fieldChars = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrixField.GetLength(1); col++)
                {
                    matrixField[row, col] = fieldChars[col];
                }
            }
        }
    }
}
