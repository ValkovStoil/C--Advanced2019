using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Reverse();
            var stackInput = new Stack<string>(input);
            stackInput.Reverse();
            var sum = int.Parse(stackInput.Pop());

            while (stackInput.Count != 0)
            {
                var action = stackInput.Pop();

                switch (action)
                {

                    case "-": 
                        sum -= int.Parse(stackInput.Pop());
                        break;
                    case "+":
                        sum += int.Parse(stackInput.Pop());
                        break;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
