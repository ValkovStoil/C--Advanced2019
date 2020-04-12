using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color = "n/a";


        public Car(string model, Engine engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;

            if (color == string.Empty)
            {
                this.Color = this.color;
            }
            else
            {
                this.Color = color;
            }
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            var line = Environment.NewLine;
            var weight = "n/a";
            var displacement = "n/a";
            if(this.Weight != 0)
            {
                weight = this.Weight.ToString();
            }

            if(this.Engine.Displacement != 0)
            {
                displacement = this.Engine.Displacement.ToString();
            }


            var result = $"{this.Model}:{line}  {this.Engine.Model}:{line}    Power: {this.Engine.Power}" +
                $"{line}    Displacement: {displacement}{line}    Efficiency: {this.Engine.Efficiency}" +
                $"{line}  Weight: {weight}{line}  Color: {this.Color}";

            return result;
        }
    }
}
