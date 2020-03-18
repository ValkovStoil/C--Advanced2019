using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split().Select(int.Parse);
            var locks = Console.ReadLine().Split().Select(int.Parse);
            var intelligence = int.Parse(Console.ReadLine());

            var locksQueue = new Queue<int>(locks);
            var bulletStack = new Stack<int>(bullets);
            var reload = gunBarrelSize;


            while (locksQueue.Count != 0 && bulletStack.Count != 0)
            {
                var bullet = bulletStack.Pop();
                var lockk = locksQueue.Peek();

                if(lockk < bullet)
                {
                    Console.WriteLine("Ping!");
                    reload--;
                }
                else
                {
                    locksQueue.Dequeue();
                    Console.WriteLine("Bang!");
                    reload--;
                }

                if (reload == 0 && bulletStack.Count > 0)
                {
                    reload = gunBarrelSize;
                    Console.WriteLine("Reloading!");
                }
            }

            if(locksQueue.Count == 0)
            {
                var bulletsUssed = bullets.Count() - bulletStack.Count;
                var price = bulletsUssed * bulletPrice;
                var earnedMoney = intelligence - price;

                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${earnedMoney}");
            }
            else
            {
                var locksLeft = locksQueue.Count;
                Console.WriteLine($"Couldn't get through. Locks left: {locksLeft}");
            }

        }
    }
}
