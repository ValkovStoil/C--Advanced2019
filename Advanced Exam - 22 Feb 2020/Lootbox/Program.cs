using System;
using System.Collections.Generic;
using System.Linq;

namespace Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstBoxInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var secondBoxInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse);

            var firstBox = new Queue<int>(firstBoxInfo);
            var secondBox = new Stack<int>(secondBoxInfo);
            var claimedItems = new List<int>();

            while (firstBox.Count != 0 && secondBox.Count != 0)
            {
                var firstItem = firstBox.Peek();
                var secondItem = secondBox.Peek();
                var itemesSum = firstItem + secondItem;

                var isEven = isEvenNumber(itemesSum);

                if (isEven)
                {
                    claimedItems.Add(itemesSum);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            if(firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if(secondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            var qualitySum = claimedItems.Sum();

            if(qualitySum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {qualitySum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {qualitySum}");
            }
        }

        private static bool isEvenNumber(int itemesSum)
        {
            return itemesSum % 2 == 0;
        }
    }
}
