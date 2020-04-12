using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var enginesCount = int.Parse(Console.ReadLine());

            var cars = new List<Car>();
            var engines = new List<Engine>();

            for (int i = 0; i < enginesCount; i++)
            {
                var inputParameters = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = string.Empty;
                var power = 0.0;
                var displacement = 0;
                var efficiency = string.Empty;

                model = inputParameters[0];
                power = double.Parse(inputParameters[1]);

                if (inputParameters.Length == 3)
                {
                    if(int.TryParse(inputParameters[2],out displacement))
                    {
                        displacement = int.Parse(inputParameters[2]);
                    }
                    else
                    {
                        efficiency = inputParameters[2];
                    }
                }

                if (inputParameters.Length == 4)
                {
                    displacement = int.Parse(inputParameters[2]);
                    efficiency = inputParameters[3];
                }

                var engine = new Engine(model, power, displacement, efficiency);

                engines.Add(engine);
            }

            var carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                var carParameters = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var model = string.Empty;
                var enginModel = string.Empty;
                var weight = 0;
                var color = string.Empty;

                model = carParameters[0];
                enginModel = carParameters[1];


                if (carParameters.Length == 3)
                {
                    if (int.TryParse(carParameters[2], out weight))
                    {
                        weight = int.Parse(carParameters[2]);
                    }
                    else
                    {
                        color = carParameters[2];
                    }
                }

                if (carParameters.Length == 4)
                {
                    weight = int.Parse(carParameters[2]);
                    color = carParameters[3];
                }

                var engine = engines.FirstOrDefault(x => x.Model == enginModel);

                var car = new Car(model, engine, weight, color);
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
