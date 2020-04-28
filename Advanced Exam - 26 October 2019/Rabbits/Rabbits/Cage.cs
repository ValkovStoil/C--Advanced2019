using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    class Cage
    {
        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Rabbit>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Rabbit rabbit)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {

            var removeRabbit = this.data
                .FirstOrDefault(n => n.Name == name);

            return this.data.Remove(removeRabbit);
        }

        public void RemoveSpecies(string species)
        {
            this.data.RemoveAll(s => s.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            var soldRabbit = this.data
                .FirstOrDefault(n => n.Name == name);

            if (soldRabbit != null)
            {
                soldRabbit.Available = false;
            }

            return soldRabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var soldRabbits = this.data
                .Where(s => s.Species == species)
                .ToList();

            foreach (var rabbit in soldRabbits)
            {
                rabbit.Available = false;
            }

            return soldRabbits.ToArray();
        }

        public string Report()
        {
            var availableRabbits = this.data
                .Where(a => a.Available == true);

            var report = new StringBuilder($"Rabbits available at {this.Name}:{Environment.NewLine}");

            foreach (var rabbit in availableRabbits)
            {
                report.AppendLine(rabbit.ToString());
            }

            return report.ToString().Trim();
        }
    }
}
