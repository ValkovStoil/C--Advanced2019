using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    class Cage : IEnumerable<Rabbit>
    {
        private List<Rabbit> data;

        public Cage(string name, int cpacity)
        {
            this.Name = name;
            this.Cpacity = cpacity;
            this.data = new List<Rabbit>();
        }

        public string Name { get; set; }

        public int Cpacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Rabbit rabbit)
        {
            if(this.Count < this.Cpacity)
            {
                this.data.Add(rabbit);
            }
        }

        

        //TODO
        public bool RemoveRabbit(string name)
        {
            var removeRabbit = this.data
                .FirstOrDefault(n => n.Name == name);

            if(removeRabbit != null)
            {
                this.data.Remove(removeRabbit);
                return true;
            }

            return false;
        }

        public void RemoveSpecies(string species)
        {
            this.data = this.data
                .Where(s => s.Species != species)
                .ToList();
        }

        public Rabbit SellRabbit(string name)
        {
            var soldRabbits = this.data
                .FirstOrDefault(n => n.Name == name);

            soldRabbits.Available = false;

            return soldRabbits;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var soldRabbits = this.data
                .Where(s => s.Species == species)
                .ToArray();

            foreach (var rabbit in soldRabbits)
            {
                rabbit.Available = false;
            }

            return soldRabbits;
        }

        public string Report()
        {
            var availableRabbits = this.data
                .Where(a => a.Available != false)
                .ToList();

            var resultString = new StringBuilder();

            resultString.AppendLine($"Rabbits available at {this.Name}:");

            foreach (var rabbit in availableRabbits)
            {
                resultString.AppendLine(rabbit.ToString());
            }

           return resultString.ToString();
        }

        public IEnumerator<Rabbit> GetEnumerator()
        {
            foreach (var rabbit in this.data)
            {
                yield return rabbit;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
