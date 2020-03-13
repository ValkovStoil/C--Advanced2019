using System;
using System.Collections.Generic;
using System.Linq;

namespace Fashion_Boutique
{
    class Program
    {
        /*
         * 5 4 8 6 3 8 7 7 9
16
         */
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var racksStorage = int.Parse(Console.ReadLine());
            var cloths = new Stack<int>(input);
            var countOfRacks = 1;
            var sumOfCloths = 0;

            while (cloths.Count > 0)
            {
                sumOfCloths += cloths.Peek();
                if(sumOfCloths <= racksStorage)
                {
                    cloths.Pop();
                }
                else
                {
                    countOfRacks++;
                    sumOfCloths = 0;
                }
            }

            Console.WriteLine(countOfRacks);
        }
    }
}
