using System;
using System.Linq;

namespace CustomStack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var myCustomStack = new MyCustomStack<int>();

            var inputCommands = Console.ReadLine()
                .Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (inputCommands[0] != "END")
            {
                var command = inputCommands[0];
                var numbers = inputCommands
                    .Skip(1)
                    .Select(int.Parse)
                    .ToArray();

                if(command == "Push")
                {
                    foreach (var number in numbers)
                    {
                        myCustomStack.Push(number);
                    }
                }
                else
                {
                    try
                    {
                        myCustomStack.Pop();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No elements");
                    }
                }

                inputCommands = Console.ReadLine()
                .Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var elemet in myCustomStack)
                {
                    Console.WriteLine(elemet);
                }
            }
        }
    }
}
