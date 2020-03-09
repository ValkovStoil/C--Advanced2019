using System;
using System.Collections.Generic;

namespace Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var helpStack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == '(')
                {
                    helpStack.Push(i);
                }
                else if (input[i] == ')')
                {
                    var index = helpStack.Pop();
                    Console.WriteLine(input.Substring(index, i - index + 1));
                }
            }
        }
    }
}
