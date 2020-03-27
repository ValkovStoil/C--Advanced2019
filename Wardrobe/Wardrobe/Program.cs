using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                var clothsAndColors = Console.ReadLine()
                    .Split(" -> ")
                    .ToArray();

                var color = clothsAndColors[0];
                var clothes = clothsAndColors[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                foreach (var dress in clothes)
                {

                    if (!wardrobe[color].ContainsKey(dress))
                    {
                        wardrobe[color][dress] = 0;
                    }
                    wardrobe[color][dress]++;
                }
            }

            var choiceOfClothes = Console.ReadLine()
                .Split(" ")
                .ToArray();

            var colors = choiceOfClothes[0];
            var cloth = choiceOfClothes[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var kvp in color.Value)
                {
                    if (color.Key == colors && kvp.Key == cloth)
                    {
                        Console.WriteLine($"* {kvp.Key} - {kvp.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {kvp.Key} - {kvp.Value}");
                    }
                }
            }
        }
    }
}
