using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbits
{
    class Cage
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
            return true;
        }
    }
}
