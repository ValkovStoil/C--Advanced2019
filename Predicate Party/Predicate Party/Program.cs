using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            var command = Console.ReadLine();

            var predicate = new Func<string, string, string, bool>(Check);

            while (command != "Party!")
            {
                var actions = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var action = actions[0].ToLower();
                var condition = actions[1];
                var parameter = actions[2];

                switch (action)
                {
                    case "double":
                        var doubleNames = new List<string>();

                        foreach (var guest in guests)
                        {
                            if (predicate(condition, guest, parameter))
                            {
                                doubleNames.Add(guest);
                            }
                        }

                        guests.AddRange(doubleNames);

                        break;
                    case "remove":
                        var removeNames = new List<string>();

                        if (guests.Count != 0)
                        {
                            foreach (var guest in guests)
                            {
                                if (predicate(condition, guest, parameter))
                                {
                                    removeNames.Add(guest);
                                }
                            }


                            foreach (var name in removeNames)
                            {
                                guests.Remove(name);
                            }
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            var names = guests.OrderBy(x => x);
            if (names.Count() > 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
        }

        private static bool Check(string condition, string word, string parameter)
        {
            if (condition == "StartsWith")
            {
                return word.StartsWith(parameter);
            }
            else if (condition == "EndsWith")
            {
                return word.EndsWith(parameter);
            }
            else if( condition == "Length")
            {
                return word.Length == int.Parse(parameter);
            }
            else
            {
                return false;
            }
        }
    }
}
