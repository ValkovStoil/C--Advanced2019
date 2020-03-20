using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
//            5
//10 20 30
//1 2 3
//2
//2
//10 10
//End


            var n = int.Parse(Console.ReadLine());
            var jaggArray = new double[n][];

            for (int row = 0; row < n; row++)
            {
                var numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                jaggArray[row] = new double[numbers.Length];

                for (int col = 0; col < numbers.Length; col++)
                {
                    jaggArray[row][col] = numbers[col];
                }
            }

            for (int row = 0; row < jaggArray.Length - 1; row++)
            {
                var first = jaggArray[row].Length;
                var second = jaggArray[row + 1].Length;

                if(first == second)
                {
                    Multiplay(jaggArray, row);
                }
                else
                {
                    Divide(jaggArray, row);
                }
            }

            var commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var command = commands[0].ToLower();

            while (command != "end")
            {

                switch (command)
                {
                    case "add":
                        if (commands.Length == 4)
                        {
                            AddToIndex(jaggArray, commands);
                        }
                        break;
                    case "subtract":
                        if (commands.Length == 4)
                        {
                            SubstractToIndex(jaggArray, commands);
                        }
                        break;
                }

                commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                command = commands[0].ToLower();
            }

            for (int row = 0; row < jaggArray.Length; row++)
            {
                for (int col = 0; col < jaggArray[row].Length; col++)
                {
                    Console.Write($"{jaggArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }

        private static void SubstractToIndex(double[][] jaggArray, string[] commands)
        {
            var row = int.Parse(commands[1]);
            var col = int.Parse(commands[2]);
            var number = int.Parse(commands[3]);
            try
            {
                jaggArray[row][col] -= number;
            }
            catch (Exception)
            {

            }
        }

        private static void AddToIndex(double[][] jaggArray, string[] commands)
        {
            var row = int.Parse(commands[1]);
            var col = int.Parse(commands[2]);
            var number = int.Parse(commands[3]);
            try
            {
                jaggArray[row][col] += number;
            }
            catch (Exception)
            {

            }
        }

        private static void Divide(double[][] jaggArray, int row)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < jaggArray[row + i].Length; j++)
                {
                    var value = jaggArray[row + i][j] / 2;
                    jaggArray[row + i][j] = value;
                }
            }
        }

        private static void Multiplay(double[][] jaggArray, int row)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < jaggArray[row+i].Length; j++)
                {
                    var value = jaggArray[row + i][j] * 2;
                    jaggArray[row + i][j] = value;
                }
            }
        }
    }
}
