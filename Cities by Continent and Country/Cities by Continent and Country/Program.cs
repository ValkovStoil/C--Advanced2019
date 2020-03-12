using System;
using System.Collections.Generic;
using System.Linq;

namespace Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dictionary = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ");
                var continent = input[0];
                var country = input[1];
                var city = input[2];

                if (!dictionary.ContainsKey(continent))
                {
                    dictionary[continent] = new Dictionary<string, List<string>>();
                }

                if (!dictionary[continent].ContainsKey(country))
                {
                    dictionary[continent][country] = new List<string>();
                }

                dictionary[continent][country].Add(city);

            }

            foreach (var continent in dictionary)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var countri in continent.Value)
                {
                    Console.WriteLine($"{countri.Key} -> {string.Join(", ", countri.Value)}");
                }
            }
        }
    }
}
