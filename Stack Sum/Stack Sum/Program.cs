using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(n=> int.Parse(n));
            var numStack = new Stack<int>(input);

            var command = Console.ReadLine().Split(' ');

            while (command[0].ToLower() != "end")
            {
                if(command[0].ToLower() == "add")
                {
                    numStack.Push(int.Parse(command[1]));
                    numStack.Push(int.Parse(command[2]));
                }
                else
                {
                    var count = int.Parse(command[1]);

                    while (count != 0 && numStack.Count >= count)
                    {
                        numStack.Pop();

                        count--;
                    }
                }


                command = Console.ReadLine().Split(' ');
            }


            Console.WriteLine($"Sum: {numStack.Sum()}");
        }
    }
}
