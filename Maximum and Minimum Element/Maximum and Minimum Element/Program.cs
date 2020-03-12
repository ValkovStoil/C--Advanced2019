using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var elements = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ");
                var type = int.Parse(input[0]);

                switch (type)
                {
                    case 1:
                        elements.Push(int.Parse(input[1]));
                        break;
                    case 2:
                        if (elements.Count != 0)
                        {
                            elements.Pop();
                        }
                        break;
                    case 3:
                        if (elements.Count != 0)
                        {
                            Console.WriteLine(elements.Max());
                        }
                        break;
                    case 4:
                        if (elements.Count != 0)
                        {
                            Console.WriteLine(elements.Min());
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", elements));
        }
    }
}
