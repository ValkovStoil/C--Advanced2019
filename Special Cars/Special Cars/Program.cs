using System;
using System.Collections.Generic;
using System.Linq;

namespace Special_Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var tires = new List<Tire[]>();
            var engines = new List<Engine>();
            var cars = new List<Car>();

            while (input != "No more tires")
            {
                var tireInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var tire1 = new Tire(int.Parse(tireInfo[0]), double.Parse(tireInfo[1]));
                var tire2 = new Tire(int.Parse(tireInfo[2]), double.Parse(tireInfo[3]));
                var tire3 = new Tire(int.Parse(tireInfo[4]), double.Parse(tireInfo[5]));
                var tire4 = new Tire(int.Parse(tireInfo[6]), double.Parse(tireInfo[7]));

                tires.Add(new Tire[] { tire1, tire2, tire3, tire4 });

                input = Console.ReadLine();
            }


            input = Console.ReadLine();

            while (input != "Engines done")
            {
                var engineInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var horsePower = int.Parse(engineInfo[0]);
                var cubicCapacity = double.Parse(engineInfo[1]);

                var engin = new Engine(horsePower, cubicCapacity);
                engines.Add(engin);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Show special")
            {
                //Audi A5 2017 200 12 0 0
                var carInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var make = carInfo[0];
                var model = carInfo[1];
                var year = int.Parse(carInfo[2]);
                var fuelQuantity = double.Parse(carInfo[3]);
                var fuelCapacity = double.Parse(carInfo[4]);
                var engine = engines[int.Parse(carInfo[5])];
                var tire = tires[int.Parse(carInfo[6])];


                var car = new Car(make, model, year, fuelQuantity, fuelCapacity, engine, tire);
                cars.Add(car);

                input = Console.ReadLine();
            }

            cars = cars
                .Where(y => y.Year >= 2017)
                .Where(h=>h.Engine.HorsePower >= 330)
                .Where(p => p.Tires.Sum(x=>x.Pressure)>= 9)
                .Where(p=>p.Tires.Sum(x=>x.Pressure) <= 10)
                .ToList();

            foreach (var car in cars)
            {
                car.Drive(20);
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");

            }
        }
    }
}
