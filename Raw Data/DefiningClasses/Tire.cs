using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Tire
    {
        public int Age { get; set; }
        public double Pressure { get; set; }

        public Tire()
        {

        }
        public Tire(double pressure, int age)
        {
            this.Age = age;
            this.Pressure = pressure;
        }
    }
}
