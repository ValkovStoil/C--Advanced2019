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

            var tires = new List<Tire>();
            var engines = new List<Engine>();
            var cars = new List<Car>();

            while (input != "No more tires")
            {
                var tireInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < tireInfo.Length; i += 2)
                {
                    var year = int.Parse(tireInfo[i]);
                    var pressure = double.Parse(tireInfo[i + 1]);

                    var tire = new Tire(year, pressure);
                    tires.Add(tire);
                }

                input = Console.ReadLine();
            }


            input = Console.ReadLine();

            while (input != "Engines done")
            {
                var engineInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var horsePower = int.Parse(engineInfo[0]);
                var cubicCapacity = double.Parse(engineInfo[1]);

                var engin = new Engine(horsePower, cubicCapacity);

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
                var engineIndex = int.Parse(carInfo[5]);
                var tireIndex = int.Parse(carInfo[6]);

             //TODO car tires not working


                var car = new Car(make, model, year, fuelQuantity, fuelCapacity, engines[engineIndex], tire);


                input = Console.ReadLine();
            }
        }
    }
}
