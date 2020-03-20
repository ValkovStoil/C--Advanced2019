using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var snake = Console.ReadLine().Trim();

            var snakeQueue = new Queue<char>(snake.ToCharArray());

            var rows = dimensions[0];
            var columns = dimensions[1];

            var matrix = new char[rows, columns];

            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        var element = snakeQueue.Dequeue();
                        matrix[row, col] = element;
                        snakeQueue.Enqueue(element);
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {

                        var element = snakeQueue.Dequeue();
                        matrix[row, col] = element;
                        snakeQueue.Enqueue(element);
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
