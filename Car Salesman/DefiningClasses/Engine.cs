using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
		private string model;
		private double power;
		private string displacement;
		private string efficiency = "n/a";


		public Engine(string model, double power, int displacement, string efficiency)
		{
			this.Model = model;
			this.Power = power;
			this.Displacement = displacement;

			if (efficiency == string.Empty)
			{
				this.Efficiency = this.efficiency;
			}
			else
			{
				this.Efficiency = efficiency;
			}
		}

		public string Model { get; set; }

		public double Power { get; set; }

		public int Displacement { get; set; }

		public string Efficiency { get; set; }

	}
}
