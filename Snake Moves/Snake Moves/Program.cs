using System;
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

            var rows = dimensions[0];
            var columns = dimensions[1];

            var matrix = new string[rows, columns];

            //TODO
        }
    }
}
