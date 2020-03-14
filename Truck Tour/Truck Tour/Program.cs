using System;
using System.Collections.Generic;
using System.Linq;

namespace Truck_Tour
{
    class Program
    {
 /*
3
1 5
10 3
3 4
*/
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var travel = new Queue<long>();

            for (int i = 0; i < n; i++)
            {
                var punpAndDistance = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                var petrol = punpAndDistance[0];
                var distance = punpAndDistance[1];

                travel.Enqueue(petrol - distance);

            }


            for (int i = 0; i < n; i++)
            {
                var travelDistance = new Queue<long>(travel);
                long distance = travelDistance.Dequeue();

                while (travelDistance.Count != 0)
                {

                    if(distance >= 0)
                    {
                        distance += travelDistance.Dequeue();
                    }
                    else
                    {
                        break;
                    }

                }

                if (distance >= 0)
                {
                    Console.WriteLine(i);
                    return;
                }

                travel.Enqueue(travel.Dequeue());
            }

        }
    }
}
