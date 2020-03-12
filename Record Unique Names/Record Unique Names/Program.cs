using System;
using System.Collections.Generic;
using System.Linq;

namespace Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var unique = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();

                unique.Add(name);
            }

            foreach (var name in unique)
            {
                Console.WriteLine(name);
            }
        }
    }
}
