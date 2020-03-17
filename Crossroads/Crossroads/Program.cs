using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            var greenLightDuration = int.Parse(Console.ReadLine());
            var freeWindowDuration = int.Parse(Console.ReadLine());
            var command = Console.ReadLine();

            var cars = new Queue<string>();
            var carsPassed = 0;

            while (command != "END")
            {
                var timeToEnter = greenLightDuration;

                if(command == "green")
                {
                    var car = string.Empty;

                    while (timeToEnter > 0 && cars.Count > 0)
                    {
                        car = cars.Dequeue();

                        var carLenght = car.Length;
                        timeToEnter -= carLenght;
                        carsPassed++;
                    }

                    var timeToPass = freeWindowDuration + timeToEnter;

                    if (timeToPass < 0)
                    {
                        var crashIndex = Math.Abs(timeToPass);
                        var charThatCrash = car.Substring(car.Length - crashIndex, 1);
                        Console.WriteLine($"A crash happened!");
                        Console.WriteLine($"{car} was hit at {charThatCrash}.");
                        return;
                    }

                }
                else
                {
                    cars.Enqueue(command);
                }


                command = Console.ReadLine();
            }

            Console.WriteLine($"Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
        }
    }
}
