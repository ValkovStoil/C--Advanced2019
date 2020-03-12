using System;
using System.Collections.Generic;
using System.Linq;

namespace Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var indexes = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var elements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var n = indexes[0];
            var s = indexes[1];
            var x = indexes[2];

            var stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                stack.Push(elements[i]);
            }

            if (stack.Count >= s)
            {
                for (int i = 0; i < s; i++)
                {
                    stack.Pop();
                }
            }

            if (stack.Count != 0)
            {
                if (!stack.Contains(x))
                { 
                    Console.WriteLine(stack.Min());
                }
                else
                {
                    Console.WriteLine("true");
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
