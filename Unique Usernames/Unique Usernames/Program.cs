using System;
using System.Collections.Generic;

namespace Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new HashSet<string>();

            var userNamesCount = int.Parse(Console.ReadLine());

            for (int user = 0; user < userNamesCount; user++)
            {
                var userName = Console.ReadLine();

                collection.Add(userName);
            }

            foreach (var name in collection)
            {
                Console.WriteLine(name);
            }
        }
    }
}
