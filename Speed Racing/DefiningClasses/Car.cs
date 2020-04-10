using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }


        public Car()
        {
            TravelledDistance = 0.0;
        }

        public Car(string model,double fuelAmount,double fuelConsumptionPerKilometer):this()
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }


        public void Drive(double distance)
        {
            var moveDistance = distance * this.FuelConsumptionPerKilometer;

            if (this.FuelAmount - moveDistance > 0)
            {
                this.FuelAmount -= moveDistance;
                this.TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
