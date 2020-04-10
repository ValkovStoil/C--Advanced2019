using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //            2
            //AudiA4 23 0.3
            //BMW-M2 45 0.42
            //Drive BMW-M2 56
            //Drive AudiA4 5
            //Drive AudiA4 13
            //End

            var n = int.Parse(Console.ReadLine());
            var cars = new HashSet<Car>();

            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = carInfo[0];
                var fuelAmount = double.Parse(carInfo[1]);
                var consumptionPerKilometer = double.Parse(carInfo[2]);

                var car = new Car(model, fuelAmount, consumptionPerKilometer);
                cars.Add(car);
            }

            var command = Console.ReadLine();

            while (command != "End")
            {
                var commandInfo = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var action = commandInfo[0];
                var carModel = commandInfo[1];
                var amountOfKM = double.Parse(commandInfo[2]);

                foreach (var car in cars)
                {
                    if(car.Model == carModel)
                    {
                        car.Drive(amountOfKM);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }

        }
    }
}
