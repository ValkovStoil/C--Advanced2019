using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    public class Iterator<T>
    {
        private int index;

        public Iterator(List<T> elements)
        {
            this.Elements = elements;
            this.index = 0;
        }

        public List<T> Elements { get; set; }

        public bool Move()
        {
            bool hasNext = HasNext();

            if (hasNext)
            {
                this.index++;
            }

            return hasNext;
        }

        public bool HasNext()
        {
            if(this.index < this.Elements.Count - 1)
            {
                return true;
            }

            return false;
        }

        public void Print()
        {
            if (!this.Elements.Any())
            {
                var message = "Invalid Operation!";
                throw new InvalidOperationException(message);
            }

            Console.WriteLine(this.Elements[index]);
        }
    }
}
