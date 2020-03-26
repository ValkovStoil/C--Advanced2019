using System;
using System.Collections.Generic;
using System.Linq;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = new SortedSet<string>();

            var n = int.Parse(Console.ReadLine());

            for (int el = 0; el < n; el++)
            {
                var chemicals = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var ch in chemicals)
                {
                    elements.Add(ch);
                }
            }

            Console.Write(string.Join(" ", elements));

        }
    }


}
