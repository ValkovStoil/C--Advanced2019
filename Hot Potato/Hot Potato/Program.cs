using System;
using System.Collections.Generic;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ");
            var num = int.Parse(Console.ReadLine());

            var children = new Queue<string>(input);

            while (children.Count > 1)
            {
                for (int i = 0; i < num - 1; i++)
                {
                    var name = children.Dequeue();
                    children.Enqueue(name);
                }

                Console.WriteLine($"Removed {children.Dequeue()}");
            }
            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
