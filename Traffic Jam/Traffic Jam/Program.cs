using System;
using System.Collections.Generic;

namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            var numPassingCars = int.Parse(Console.ReadLine());
            var car = Console.ReadLine();
            var cars = new Queue<string>();
            var countCarsPassed = 0;


            while (car != "end")
            {
                if (car != "green")
                {
                    cars.Enqueue(car);
                }
                else if (car == "green")
                {
                    if (cars.Count != 0)
                    {
                        var carsCount = cars.Count;
                        if (cars.Count < numPassingCars)
                        {
                            for (int vehicle = 0; vehicle < carsCount; vehicle++)
                            {
                                Console.WriteLine($"{cars.Dequeue()} passed!");
                                countCarsPassed++;
                            }
                        }
                        else
                        {
                            for (int vehicle = 0; vehicle < numPassingCars; vehicle++)
                            {
                                Console.WriteLine($"{cars.Dequeue()} passed!");
                                countCarsPassed++;
                            }
                        }
                    }
                }
                car = Console.ReadLine();
            }


            Console.WriteLine($"{countCarsPassed} cars passed the crossroads.");
        }


    }
}

