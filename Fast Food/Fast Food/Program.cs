using System;
using System.Collections.Generic;
using System.Linq;

namespace Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            var quantity = int.Parse(Console.ReadLine());
            var orderQuantity = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            var orders = new Queue<int>(orderQuantity);
            var maxOrder = orders.Max();


            while (orders.Count > 0 && orders.Peek() <= quantity)
            {
                quantity -= orders.Dequeue();
            }

            Console.WriteLine(maxOrder);

            if (orders.Count == 0 && quantity >= 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }
    }
}
