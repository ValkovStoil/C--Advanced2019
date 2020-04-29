using System;
using System.Collections.Generic;
using System.Linq;

namespace SantasPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var presentsAndMagicNeeded = new Dictionary<string, int>();
            presentsAndMagicNeeded["Doll"] = 150;
            presentsAndMagicNeeded["Wooden train"] = 250;
            presentsAndMagicNeeded["Teddy bear"] = 300;
            presentsAndMagicNeeded["Bicycle"] = 400;

            var craftedToys = new Dictionary<string, int>();

            craftedToys["Doll"] = 0;
            craftedToys["Wooden train"] = 0;
            craftedToys["Teddy bear"] = 0;
            craftedToys["Bicycle"] = 0;

            var materialsInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var magicLevelInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var materials = new Stack<int>(materialsInput);
            var magicLevels = new Queue<int>(magicLevelInput);

            while (materials.Count != 0 && magicLevels.Count != 0)
            {

                var material = materials.Peek();
                var magicLevel = magicLevels.Peek();

                if (material == 0 || magicLevel == 0)
                {
                    if (material == 0)
                    {
                        materials.Pop();
                    }
                    if (magicLevel == 0)
                    {
                        magicLevels.Dequeue();
                    }
                    continue;
                }

                var totalMagicLevel = material * magicLevel;

                if (totalMagicLevel > 0)
                {
                    var canCraft = IsCraftable(presentsAndMagicNeeded, totalMagicLevel);

                    if (canCraft)
                    {
                        CraftToy(presentsAndMagicNeeded, craftedToys, materials, magicLevels, totalMagicLevel);
                    }
                    else
                    {
                        materials.Push(materials.Pop() + 15);
                        magicLevels.Dequeue();
                    }
                }
                else
                {
                    var tempMat = material + magicLevel;

                    materials.Pop();
                    magicLevels.Dequeue();

                    materials.Push(tempMat);
                }
            }

            craftedToys = craftedToys
                .OrderBy(k => k.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            if (craftedToys["Doll"] > 0 && craftedToys["Wooden train"] > 0
                || craftedToys["Teddy bear"] > 0 && craftedToys["Bicycle"] > 0)
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Any())
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }

            if (magicLevels.Any())
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magicLevels)}");
            }

            foreach (var (toy, amount) in craftedToys)
            {
                if (amount > 0)
                {
                    Console.WriteLine($"{toy}: {amount}");
                }
            }
        }

        private static bool IsCraftable(Dictionary<string, int> presentsAndMagicNeeded, int totalMagicLevel)
        {
            foreach ((string toy, int lvl) in presentsAndMagicNeeded)
            {
                if (totalMagicLevel == lvl)
                {
                    return true;
                }
            }
            return false;
        }

        private static void CraftToy(Dictionary<string, int> presentsAndMagicNeeded, Dictionary<string, int> craftedToys, Stack<int> materials, Queue<int> magicLevels, int totalMagicLevel)
        {
            foreach (var (toy, lvl) in presentsAndMagicNeeded)
            {
                if (totalMagicLevel == lvl)
                {
                    craftedToys[toy]++;

                    materials.Pop();
                    magicLevels.Dequeue();
                    break;
                }
            }
        }
    }
}
