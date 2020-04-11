using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

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

            cars = cars.Distinct().ToList();

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
