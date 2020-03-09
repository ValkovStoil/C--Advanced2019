using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputName = Console.ReadLine();
            var queNames = new Queue<string>();

            while (inputName != "End")
            {
                if (inputName == "Paid")
                {
                    while (queNames.Count != 0)
                    {
                        Console.WriteLine($"{queNames.Dequeue()}");
                    }
                }
                else
                { 
                   queNames.Enqueue(inputName);
                }
                inputName = Console.ReadLine();
            }
            Console.WriteLine($"{queNames.Count()} people remaining.");
        }
    }
}
