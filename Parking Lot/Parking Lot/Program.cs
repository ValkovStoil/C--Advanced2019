using System;
using System.Collections.Generic;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            var carNumber = Console.ReadLine().Split(", ");
            var carsIn = new HashSet<string>();

            while (carNumber[0] != "END")
            {
                var direction = carNumber[0];
                var number = carNumber[1];

                switch (direction)
                {
                    case "IN":
                        carsIn.Add(number);
                        break;
                    case "OUT":
                        carsIn.Remove(number);
                        break;
                }

                carNumber = Console.ReadLine().Split(", ");
            }

            if (carsIn.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in carsIn)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
