using System;
using System.Collections.Generic;

namespace Reverse_String
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var inputStack = new Stack<char>(input);

            while (inputStack.Count != 0)
            {
                Console.Write(inputStack.Pop());

            }

        }
    }
}
