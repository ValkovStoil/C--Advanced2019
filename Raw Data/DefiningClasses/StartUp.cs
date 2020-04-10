using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();


            for (int i = 0; i < n; i++)
            {
                var inputInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = inputInfo[0];
                var engineSpeed = int.Parse(inputInfo[1]);
                var enginPower = int.Parse(inputInfo[2]);
                var cargoWeight = int.Parse(inputInfo[3]);
                var cargoType = inputInfo[4];

                var tires = new Tire[]
                {
                    new Tire(double.Parse(inputInfo[5]),int.Parse(inputInfo[6])),
                    new Tire(double.Parse(inputInfo[7]),int.Parse(inputInfo[8])),
                    new Tire(double.Parse(inputInfo[9]),int.Parse(inputInfo[10])),
                    new Tire(double.Parse(inputInfo[11]),int.Parse(inputInfo[12])),
                };


                var engine = new Engine(engineSpeed, enginPower);
                var cargo = new Cargo(cargoWeight, cargoType);

                var car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            var command = Console.ReadLine();

            if(command == "fragile")
            {
                cars = cars
                     .Where(car => car.Cargo.CargoType == "fragile")
                     .Where(car => (car.Tires.Sum(p => p.Pressure) / 4 < 1))
                     .ToList();

                foreach (var car in cars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if(command == "flamable")
            {
                cars = cars
                    .Where(car => car.Cargo.CargoType == "flamable")
                    .Where(car => car.Engine.EnginePower > 250)
                    .ToList();

                foreach (var car in cars)
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
