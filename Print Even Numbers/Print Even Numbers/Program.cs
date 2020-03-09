using System;
using System.Collections.Generic;
using System.Linq;

namespace Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(n => int.Parse(n));
            var que = new Queue<int>(input);
            var output = new List<int>();

            while (que.Count != 0)
            {
                var numToChek = que.Dequeue();
                
                if(numToChek % 2 == 0)
                {
                    output.Add(numToChek);
                }
            }
            Console.Write(String.Join(", ", output.ToArray()));
        }
    }
}
